Open CERTIFYWebHookAPI.sln or CERTIFYWebHookAPI.csproj
Restore Nuget Packages
Build the project
Run - Should run as https://localhost:44380/api/report or http://localhost:38106/api/report


==Testing CERTIFY.me Webhook Reporting API===

Using NGROK 
ngrok http 44380 -host-header="localhost:44380"
Access with external proxy url. Ex: https://ed3b6f3d700d.ngrok.io/api/report

Using POSTMAN
https://localhost:44380/api/report
Required Headers
  HMAC:AQAAAAEAACcQAAAAEAcf4SGE/WxLIvNClJvy/IhkMk/iJUDKCLM4+kROq1EYGkxKFq/v0cPgEL2T53ebyg==
  Content-Type	application/json
