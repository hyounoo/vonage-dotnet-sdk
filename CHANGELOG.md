# v6.3.1 (2023-05-19)

* feat: proactive connect
* feat: add optional claims when generating a token
* feat: verifyV2 BYOP
* feat: verifyV2 Cancel
* feat: verifyV2 fraud check
* feat: voice advanced machine detection

**Full Changelog**: https://github.com/Vonage/vonage-dotnet-sdk/compare/v6.2.0...v6.3.0

---

# v6.2.0 (2023-04-19)

* fix: missing dependencies
* refactor: make builders internal

**Full Changelog**: https://github.com/Vonage/vonage-dotnet-sdk/compare/v6.1.0...v6.2.0

---

# v6.1.0 (2023-04-17)

* feat: add premium to start talk request
* feat: webhook classes for messages
* refactor: remove duplicate code for sync version of methods
* refactor: extend responses and monads capabilities
* style: unify test class names
* fix: add basic auth support for Messages

**Full Changelog**: https://github.com/Vonage/vonage-dotnet-sdk/compare/v6.0.5...v6.1.0

---

# v6.0.5 (2023-03-27)

* Fix Numbers Api authentication to match Api specs
* Add latest Messages features
* Remove hardcoded keys from the repository
* Use System.Text.Json instead of Newtonsoft for Messages Api
* New Vonage.Common project
* Readme update

**Full Changelog**: https://github.com/Vonage/vonage-dotnet-sdk/compare/v6.0.4...v6.0.5

---

# v6.0.4 (2023-01-13)

* Align frameworks on netstandard2.0
* Subaccount support

**Full Changelog**: https://github.com/Vonage/vonage-dotnet-sdk/compare/v6.0.3...v6.0.4

---

# v6.0.3 (2022-08-04)

- First v6 general release.

---

# v6.0.2-rc (2022-05-31)

- Adding Real Time Data for Advanced Number Insights

---

# v6.0.1-rc (2022-05-25)

- Reinstating .ToString method on Ncco class
- Making Vonage serialization settings public
- Removing `VersionPrefix` from project file as to not confuse
- Renaming Number Insights methods so not confusing between `async` and `Asynchronous`

---

# v6.0.0-rc (2022-05-24)

- Removing legacy Nexmo classes that have been marked as obsolete in previous versions
- Renaming enums to use Pascal Case as is accepted practice
- Moving serialisation settings to a single location
- Adding methods for new Messages API (SMS, MMS, WhatsApp, Messenger, Viber)
- Refactoring NCCO class to use List as it's base class
- Misc. refactoring

---

# v5.10.0 (2022-04-20)

- Real-Time data for advanced number insights
- Unit Test refactoring
- Authentication exceptions to give more information if incorrect authentication credentials are supplied

---

# v5.9.5 (2022-01-19)

- NCCO Input "Type" property added to align with documentation

---

# v5.9.3 (2021-11-23)

- Fixing an issue caused by the usage of a non thread safe Dictionary.

---

# v5.9.2 (2021-11-04)

- Fixing issue with Advance Number Insights throwing an exception when status = `not_roaming`

---