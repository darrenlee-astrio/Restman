using Restman.Application.Common.Models.AppData.Collections;
using Restman.Application.Common.Models.AppData.Configuration;
using Restman.Application.Common.Models.AppData.Request;

namespace Restman.Winform.Common.Helpers;

public static class DataHelper
{
    public static string GetSampleYaml()
    {
        var collection = new RequestCollection
        {
            Id = "Reqres",
            Name = "Reqres",
            Description = "A sample api for testing",
            BaseUrl = "https://reqres.in",
            Requests = new List<RequestItem>
            {
                new RequestItem
                {
                    Name = "Get Users",
                    Description = "Gets all users",
                    Method = "GET",
                    EndUrl = "/api/users",
                    HeaderConfigurations = new List<HeaderConfiguration>
                    {
                        new HeaderConfiguration
                        {
                            Enable = true,
                            Key = "x-api-key",
                            Value = "overwrite api key"
                        },
                        new HeaderConfiguration
                        {
                            Enable = true,
                            Key = "test",
                            Value = "1234"
                        }
                    },
                    QueryParameterConfigurations = new List<QueryParameterConfiguration>
                    {
                        new QueryParameterConfiguration
                        {
                            Enable = false,
                            Key = "delay",
                            Value = "3"
                        }
                    }
                },
                new RequestItem
                {
                    Name = "Get User",
                    Description = "Gets single user by id",
                    Method = "GET",
                    EndUrl = "/api/users/1"
                },
                new RequestItem
                {
                    Name = "Create User",
                    Description = "Creates a user",
                    Method = "POST",
                    EndUrl = "/api/users",
                    JsonConfiguration =
                    """
                    {
                      "name": "morpheus",
                      "job": "leader"
                    }
                    """
                },
                new RequestItem
                {
                    Name = "Update User",
                    Description = "Updates a user by id",
                    Method = "PUT",
                    EndUrl = "/api/users/1",
                    JsonConfiguration =
                    """
                    {
                      "name": "morpheus",
                      "job": "employee"
                    }
                    """
                },
                new RequestItem
                {
                    Name = "Delete User",
                    Description = "Deletes a user by id",
                    Method = "DELETE",
                    EndUrl = "/api/users/1",
                }
            }
        };
        return YamlHelper.Serialize(new List<RequestCollection> { collection });
    }
}
