using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChargeBee.Telemetry;

namespace ChargeBee.Api
{
    public static class TelemetryExecutor
    {
        public static EntityResult ExecuteEntityRequest(
            ApiConfig env,
            string telemetryResource,
            string telemetryOperation,
            HttpMethod method,
            string urlPath,
            string subDomain,
            Dictionary<string, string> headers,
            Func<Dictionary<string, string>, EntityResult> action)
        {
            var adapter = env.TelemetryAdapter;
            ResolveMetadata(ref telemetryResource, ref telemetryOperation, method, urlPath);
            if (adapter == null || string.IsNullOrEmpty(telemetryResource) || string.IsNullOrEmpty(telemetryOperation))
            {
                return action(null);
            }

            var stopwatch = Stopwatch.StartNew();
            var telemetryHeaders = new Dictionary<string, string>();
            object handle = StartTelemetry(env, adapter, telemetryResource, telemetryOperation, method, urlPath, subDomain, headers, telemetryHeaders);

            try
            {
                var response = action(telemetryHeaders.Count == 0 ? null : telemetryHeaders);
                EndTelemetrySuccess(adapter, handle, stopwatch.ElapsedMilliseconds, (int)response.StatusCode);
                return response;
            }
            catch (Exception ex)
            {
                EndTelemetryFailure(adapter, handle, stopwatch.ElapsedMilliseconds, ex);
                throw;
            }
        }

        public static async Task<EntityResult> ExecuteEntityRequestAsync(
            ApiConfig env,
            string telemetryResource,
            string telemetryOperation,
            HttpMethod method,
            string urlPath,
            string subDomain,
            Dictionary<string, string> headers,
            Func<Dictionary<string, string>, Task<EntityResult>> action)
        {
            var adapter = env.TelemetryAdapter;
            ResolveMetadata(ref telemetryResource, ref telemetryOperation, method, urlPath);
            if (adapter == null || string.IsNullOrEmpty(telemetryResource) || string.IsNullOrEmpty(telemetryOperation))
            {
                return await action(null).ConfigureAwait(false);
            }

            var stopwatch = Stopwatch.StartNew();
            var telemetryHeaders = new Dictionary<string, string>();
            object handle = StartTelemetry(env, adapter, telemetryResource, telemetryOperation, method, urlPath, subDomain, headers, telemetryHeaders);

            try
            {
                var response = await action(telemetryHeaders.Count == 0 ? null : telemetryHeaders).ConfigureAwait(false);
                EndTelemetrySuccess(adapter, handle, stopwatch.ElapsedMilliseconds, (int)response.StatusCode);
                return response;
            }
            catch (Exception ex)
            {
                EndTelemetryFailure(adapter, handle, stopwatch.ElapsedMilliseconds, ex);
                throw;
            }
        }

        public static ListResult ExecuteListRequest(
            ApiConfig env,
            string telemetryResource,
            string telemetryOperation,
            string urlPath,
            string subDomain,
            Dictionary<string, string> headers,
            Func<Dictionary<string, string>, ListResult> action)
        {
            var adapter = env.TelemetryAdapter;
            ResolveMetadata(ref telemetryResource, ref telemetryOperation, HttpMethod.GET, urlPath);
            if (adapter == null || string.IsNullOrEmpty(telemetryResource) || string.IsNullOrEmpty(telemetryOperation))
            {
                return action(null);
            }

            var stopwatch = Stopwatch.StartNew();
            var telemetryHeaders = new Dictionary<string, string>();
            object handle = StartTelemetry(env, adapter, telemetryResource, telemetryOperation, HttpMethod.GET, urlPath, subDomain, headers, telemetryHeaders);

            try
            {
                var response = action(telemetryHeaders.Count == 0 ? null : telemetryHeaders);
                EndTelemetrySuccess(adapter, handle, stopwatch.ElapsedMilliseconds, (int)response.StatusCode);
                return response;
            }
            catch (Exception ex)
            {
                EndTelemetryFailure(adapter, handle, stopwatch.ElapsedMilliseconds, ex);
                throw;
            }
        }

        public static async Task<ListResult> ExecuteListRequestAsync(
            ApiConfig env,
            string telemetryResource,
            string telemetryOperation,
            string urlPath,
            string subDomain,
            Dictionary<string, string> headers,
            Func<Dictionary<string, string>, Task<ListResult>> action)
        {
            var adapter = env.TelemetryAdapter;
            ResolveMetadata(ref telemetryResource, ref telemetryOperation, HttpMethod.GET, urlPath);
            if (adapter == null || string.IsNullOrEmpty(telemetryResource) || string.IsNullOrEmpty(telemetryOperation))
            {
                return await action(null).ConfigureAwait(false);
            }

            var stopwatch = Stopwatch.StartNew();
            var telemetryHeaders = new Dictionary<string, string>();
            object handle = StartTelemetry(env, adapter, telemetryResource, telemetryOperation, HttpMethod.GET, urlPath, subDomain, headers, telemetryHeaders);

            try
            {
                var response = await action(telemetryHeaders.Count == 0 ? null : telemetryHeaders).ConfigureAwait(false);
                EndTelemetrySuccess(adapter, handle, stopwatch.ElapsedMilliseconds, (int)response.StatusCode);
                return response;
            }
            catch (Exception ex)
            {
                EndTelemetryFailure(adapter, handle, stopwatch.ElapsedMilliseconds, ex);
                throw;
            }
        }

        private static object StartTelemetry(
            ApiConfig env,
            ITelemetryAdapter adapter,
            string telemetryResource,
            string telemetryOperation,
            HttpMethod method,
            string urlPath,
            string subDomain,
            Dictionary<string, string> requestHeaders,
            Dictionary<string, string> telemetryHeaders)
        {
            try
            {
                var fullUrl = BuildHttpUrl(env, urlPath, subDomain);
                var uri = new Uri(fullUrl);
                var context = TelemetrySupport.BuildRequestTelemetryContext(
                    telemetryResource,
                    telemetryOperation,
                    method.ToString(),
                    uri.Scheme + "://" + uri.Authority + uri.AbsolutePath,
                    uri.Host,
                    env.SiteName,
                    TelemetrySupport.ResolveChargebeeApiVersion("/api/" + ApiConfig.API_VERSION),
                    ApiConfig.Version,
                    requestHeaders);
                return adapter.OnRequestStart(context, telemetryHeaders);
            }
            catch (Exception ex)
            {
                LogTelemetryWarning("[Chargebee] Telemetry adapter OnRequestStart failed: " + ex.Message);
                return null;
            }
        }

        private static void EndTelemetrySuccess(ITelemetryAdapter adapter, object handle, long durationMs, int httpStatusCode)
        {
            try
            {
                adapter.OnRequestEnd(handle, TelemetrySupport.BuildRequestTelemetryResult(httpStatusCode, durationMs, null));
            }
            catch (Exception ex)
            {
                LogTelemetryWarning("[Chargebee] Telemetry adapter OnRequestEnd failed: " + ex.Message);
            }
        }

        private static void EndTelemetryFailure(ITelemetryAdapter adapter, object handle, long durationMs, Exception ex)
        {
            var status = TelemetrySupport.ExtractHttpStatusCode(ex) ?? 500;
            try
            {
                adapter.OnRequestEnd(
                    handle,
                    TelemetrySupport.BuildRequestTelemetryResult(status, durationMs, TelemetrySupport.ExtractRequestTelemetryError(ex)));
            }
            catch (Exception telemetryEx)
            {
                LogTelemetryWarning("[Chargebee] Telemetry adapter OnRequestEnd failed: " + telemetryEx.Message);
            }
        }

        private static void LogTelemetryWarning(string message)
        {
#if NETSTANDARD1_2
            System.Diagnostics.Debug.WriteLine(message);
#else
            Console.WriteLine(message);
#endif
        }

        private static string BuildHttpUrl(ApiConfig env, string urlPath, string subDomain)
        {
            var relativePath = urlPath.StartsWith("/") ? urlPath : "/" + urlPath;
            var baseUrl = subDomain != null ? env.ApiBaseUrlWithSubDomain(subDomain) : env.ApiBaseUrl;
            var uri = new Uri(baseUrl + relativePath);
            return uri.Scheme + "://" + uri.Authority + uri.AbsolutePath;
        }

        private static void ResolveMetadata(
            ref string telemetryResource,
            ref string telemetryOperation,
            HttpMethod method,
            string urlPath)
        {
            if (!string.IsNullOrEmpty(telemetryResource) && !string.IsNullOrEmpty(telemetryOperation))
            {
                return;
            }

            var segments =
                urlPath
                    .Split(new[] { '?' }, 2)[0]
                    .Split('/')
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToList();
            if (segments.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(telemetryResource))
            {
                telemetryResource = Singularize(segments[0]);
            }
            if (!string.IsNullOrEmpty(telemetryOperation))
            {
                return;
            }

            if (segments.Count > 2)
            {
                telemetryOperation = segments[segments.Count - 1];
            }
            else if (segments.Count == 2 && method == HttpMethod.GET)
            {
                telemetryOperation = "retrieve";
            }
            else if (segments.Count == 2 && method == HttpMethod.POST)
            {
                telemetryOperation = "update";
            }
            else if (segments.Count == 1 && method == HttpMethod.GET)
            {
                telemetryOperation = "list";
            }
            else if (segments.Count == 1 && method == HttpMethod.POST)
            {
                telemetryOperation = "create";
            }
            else
            {
                telemetryOperation = "request";
            }
        }

        private static string Singularize(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            if (value.EndsWith("ies"))
            {
                return value.Substring(0, value.Length - 3) + "y";
            }
            if (value.EndsWith("s") && !value.EndsWith("ss"))
            {
                return value.Substring(0, value.Length - 1);
            }
            return value;
        }
    }
}
