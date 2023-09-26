namespace ChargeBee.Internal
{
	public class IdempotencyConstants
	{
		public const string IDEMPOTENCY_HEADER = "chargebee-idempotency-key";
        public const string IDEMPOTENCY_REPLAY_HEADER = "chargebee-idempotency-replayed";
	}
}