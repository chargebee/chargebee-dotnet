.PHONY: help update-version increment-major increment-minor increment-patch test build clean restore pack format

VERSION_FILE := VERSION
CSPROJ_FILE := ChargeBee/ChargeBee.csproj
APICONFIG_FILE := ChargeBee/Api/ApiConfig.cs

.DEFAULT_GOAL := help

help: ## List all available commands
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "  \033[36m%-20s\033[0m %s\n", $$1, $$2}'

update-version: ## Update version across package files (requires VERSION=x.y.z)
	@echo "$(VERSION)" > $(VERSION_FILE)
	@perl -i -pe 'BEGIN{$$found=0;} if (!$$found && /<Version>[.\-\d\w]+<\/Version>/) { s|<Version>[.\-\d\w]+</Version>|<Version>$(VERSION)</Version>|; $$found=1; }' $(CSPROJ_FILE)
	@perl -pi -e 's|public static string Version = "[.\-\d\w]+"|public static string Version = "$(VERSION)"|' $(APICONFIG_FILE)
	@echo "Updated version to $(VERSION)"

increment-major: ## Bump the major version
	$(eval CURRENT := $(shell cat $(VERSION_FILE)))
	$(eval MAJOR := $(shell echo $(CURRENT) | cut -d. -f1))
	$(eval NEW_VERSION := $(shell echo $$(($(MAJOR) + 1)).0.0))
	@$(MAKE) update-version VERSION=$(NEW_VERSION)
	@echo "Version bumped from $(CURRENT) to $(NEW_VERSION)"

increment-minor: ## Bump the minor version
	$(eval CURRENT := $(shell cat $(VERSION_FILE)))
	$(eval MAJOR := $(shell echo $(CURRENT) | cut -d. -f1))
	$(eval MINOR := $(shell echo $(CURRENT) | cut -d. -f2))
	$(eval NEW_VERSION := $(MAJOR).$(shell echo $$(($(MINOR) + 1))).0)
	@$(MAKE) update-version VERSION=$(NEW_VERSION)
	@echo "Version bumped from $(CURRENT) to $(NEW_VERSION)"

increment-patch: ## Bump the patch version
	$(eval CURRENT := $(shell cat $(VERSION_FILE)))
	$(eval MAJOR := $(shell echo $(CURRENT) | cut -d. -f1))
	$(eval MINOR := $(shell echo $(CURRENT) | cut -d. -f2))
	$(eval PATCH := $(shell echo $(CURRENT) | cut -d. -f3))
	$(eval NEW_VERSION := $(MAJOR).$(MINOR).$(shell echo $$(($(PATCH) + 1))))
	@$(MAKE) update-version VERSION=$(NEW_VERSION)
	@echo "Version bumped from $(CURRENT) to $(NEW_VERSION)"

restore: ## Restore dependencies
	dotnet restore

test: ## Run the test suite
	dotnet test

build: ## Build in Release configuration
	dotnet build --configuration Release

clean: ## Remove build output and packages
	dotnet clean
	rm -rf ChargeBee/bin ChargeBee/obj
	rm -rf Chargebee.Tests/bin Chargebee.Tests/obj
	rm -rf nupkg/*.nupkg

prepack: ## Pack the NuGet package into nupkg/
	dotnet pack ChargeBee/ChargeBee.csproj --configuration Release --output nupkg

format: ## Format the code (not configured)
	@echo "Formatter not configured."