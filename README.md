# HubSpot Integrations

Follow these steps to run the application:

1. Clone the project.

2. Restore Dependencies:  
   Open the Terminal:  
   View -> Terminal  
   In the terminal type: `dotnet restore`.

3. Update `appsettings.json` with your HubSpot API token:  
   ```json
   {
     "HubSpotSettings": {
       "BaseUrl": "https://api.hubapi.com",
       "Token": "Access Token"
     }
   }

