
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using static Google.Apis.Drive.v3.DriveService;
using System.IO;

namespace PalletExcel
{
    public class Googledrive
    {
        public static DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = "access_token",
                RefreshToken = "refreash_token",
            };


            var applicationName = "googledrivepaller";// Use the name of the project in Google Cloud
            var username = "your_email"; // Use your email


            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "client_id",
                    ClientSecret = "client_secret",
                },
                Scopes = new[] { Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            }); UserCredential credential = new(apiCodeFlow, username, tokenResponse);
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });
            return service;
        }
        public static string CreateFolder()
        {
            var service = GetService();
            var driveFolder = new Google.Apis.Drive.v3.Data.File();
            driveFolder.Name = "pallet_excels";
            driveFolder.MimeType = "application/vnd.google-apps.folder";
            driveFolder.Parents = new string[] { "parent_file_id" };
            var command = service.Files.Create(driveFolder);
            var file = command.Execute();
            return file.Id;
        }
        public string UploadFile(Stream f_t)
        {
            DriveService service = GetService();
            var driveFile = new Google.Apis.Drive.v3.Data.File();
            driveFile.Name = "test";
            driveFile.Description = "test";
            driveFile.MimeType = "application/vnd.google-apps.folder";
            driveFile.Parents = new string[] { "file_id" };

            var request = service.Files.Create(driveFile, f_t, "application/vnd.google-apps.folder" );
            request.Fields = "id";

            var response = request.Upload();
            if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                throw response.Exception;

            return request.ResponseBody.Id;
        }

      
    }



}
