Open CERTIFYWebHookAPI.sln or .csproj
Restore Nuget Packages
Build the project
Run - Should run as https://localhost:44380/api/report or http://localhost:38106/api/report


Testing CERTIFY.me Webhook Reporting API

Using NGROK 
ngrok http 52272 -host-header="localhost:52272"
https://ed3b6f3d700d.ngrok.io/api/report

USING POSTMAN
https://localhost:44380/api/report

Headers
HMAC:AQAAAAEAACcQAAAAEAcf4SGE/WxLIvNClJvy/IhkMk/iJUDKCLM4+kROq1EYGkxKFq/v0cPgEL2T53ebyg==
Content-Type	application/json
