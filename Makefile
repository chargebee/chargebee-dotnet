.PHONY: update-version increment-major increment-minor increment-patch test build clean restore pack

VERSION_FILE := VERSION
CSPROJ_FILE := ChargeBee/ChargeBee.csproj
APICONFIG_FILE := ChargeBee/Api/ApiConfig.cs

update-version:
	@echo "$(VERSION)" > $(VERSION_FILE)
	@perl -i -pe 'BEGIN{$$found=0;} if (!$$found && /<Version>[.\-\d\w]+<\/Version>/) { s|<Version>[.\-\d\w]+</Version>|<Version>$(VERSION)</Version>|; $$found=1; }' $(CSPROJ_FILE)
	@perl -pi -e 's|public static string Version = "[.\-\d\w]+"|public static string Version = "$(VERSION)"|' $(APICONFIG_FILE)
	@echo "Updated version to $(VERSION)"

increment-major:
	$(eval CURRENT := $(shell cat $(VERSION_FILE)))
	$(eval MAJOR := $(shell echo $(CURRENT) | cut -d. -f1))
	$(eval NEW_VERSION := $(shell echo $$(($(MAJOR) + 1)).0.0))
	@$(MAKE) update-version VERSION=$(NEW_VERSION)
	@echo "Version bumped from $(CURRENT) to $(NEW_VERSION)"

increment-minor:
	$(eval CURRENT := $(shell cat $(VERSION_FILE)))
	$(eval MAJOR := $(shell echo $(CURRENT) | cut -d. -f1))
	$(eval MINOR := $(shell echo $(CURRENT) | cut -d. -f2))
	$(eval NEW_VERSION := $(MAJOR).$(shell echo $$(($(MINOR) + 1))).0)
	@$(MAKE) update-version VERSION=$(NEW_VERSION)
	@echo "Version bumped from $(CURRENT) to $(NEW_VERSION)"

increment-patch:
	$(eval CURRENT := $(shell cat $(VERSION_FILE)))
	$(eval MAJOR := $(shell echo $(CURRENT) | cut -d. -f1))
	$(eval MINOR := $(shell echo $(CURRENT) | cut -d. -f2))
	$(eval PATCH := $(shell echo $(CURRENT) | cut -d. -f3))
	$(eval NEW_VERSION := $(MAJOR).$(MINOR).$(shell echo $$(($(PATCH) + 1))))
	@$(MAKE) update-version VERSION=$(NEW_VERSION)
	@echo "Version bumped from $(CURRENT) to $(NEW_VERSION)"

restore:
	dotnet restore

test:
	dotnet test

build:
	dotnet build --configuration Release

clean:
	dotnet clean
	rm -rf ChargeBee/bin ChargeBee/obj
	rm -rf Chargebee.Tests/bin Chargebee.Tests/obj
	rm -rf nupkg/*.nupkg

prepack:
	dotnet pack ChargeBee/ChargeBee.csproj --configuration Release --output nupkg