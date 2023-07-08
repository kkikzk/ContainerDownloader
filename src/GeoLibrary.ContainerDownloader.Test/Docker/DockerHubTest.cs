using GeoLibrary.ContainerDownloader.Docker;
using GeoLibrary.ContainerDownloader.Test.Mock;

namespace GeoLibrary.ContainerDownloader.Test.Docker;

public class DockerHubTest
{
    [Fact]
    [Trait("Category", nameof(DockerHub))]
    public async Task Test001()
    {
        // arrange
        static IEnumerable<string> getContens()
        {
            yield return @"
            {
                ""token"": ""eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOlt7InR5cGUiOiJyZXBvc2l0b3J5IiwibmFtZSI6ImxpYnJhcnkvdWJ1bnR1IiwiYWN0aW9ucyI6WyJwdWxsIl0sInBhcmFtZXRlcnMiOnsicHVsbF9saW1pdCI6IjEwMCIsInB1bGxfbGltaXRfaW50ZXJ2YWwiOiIyMTYwMCJ9fV0sImF1ZCI6InJlZ2lzdHJ5LmRvY2tlci5pbyIsImV4cCI6MTY4ODc4MzM0NCwiaWF0IjoxNjg4NzgzMDQ0LCJpc3MiOiJhdXRoLmRvY2tlci5pbyIsImp0aSI6ImRja3JfanRpX2FmdFRDNDJSamZjTVdPOE5JQktFZnNxVGVSRT0iLCJuYmYiOjE2ODg3ODI3NDQsInN1YiI6IiJ9.QYbxufuKk5E1RU8wjRo5wrfTQmoNOrqsU553IRZv7pRIqVpWIn3s2vYC-zw7Sx2OriwlJ4n7xc9fkEMXMzAhQ-Bdx05KcqkWvMAGnQKYkUb2XQHVkka18spXfAyZ6BQ-MA3X87op7zbY_S84D12sB49NtiIeyw8TAot9Djh61rn9gI7F-jAsLThQ2xBddfbDwqMB_WrDs54xHnl66CC36GGw7wTKNlK-zPKDF_nfZQxjW5EjGd5UO4QoUtj3iMQZTH_hA3ajVXM9ZGrjK0hDgbb-hcPFRN6UgVKkZjtDZxBcCnxIAKSXaTqY9p_1sX-Ku3x_d0KlXmk6ZmUCwD2Dcg"",
                ""access_token"": ""eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOlt7InR5cGUiOiJyZXBvc2l0b3J5IiwibmFtZSI6ImxpYnJhcnkvdWJ1bnR1IiwiYWN0aW9ucyI6WyJwdWxsIl0sInBhcmFtZXRlcnMiOnsicHVsbF9saW1pdCI6IjEwMCIsInB1bGxfbGltaXRfaW50ZXJ2YWwiOiIyMTYwMCJ9fV0sImF1ZCI6InJlZ2lzdHJ5LmRvY2tlci5pbyIsImV4cCI6MTY4ODc4MzM0NCwiaWF0IjoxNjg4NzgzMDQ0LCJpc3MiOiJhdXRoLmRvY2tlci5pbyIsImp0aSI6ImRja3JfanRpX2FmdFRDNDJSamZjTVdPOE5JQktFZnNxVGVSRT0iLCJuYmYiOjE2ODg3ODI3NDQsInN1YiI6IiJ9.QYbxufuKk5E1RU8wjRo5wrfTQmoNOrqsU553IRZv7pRIqVpWIn3s2vYC-zw7Sx2OriwlJ4n7xc9fkEMXMzAhQ-Bdx05KcqkWvMAGnQKYkUb2XQHVkka18spXfAyZ6BQ-MA3X87op7zbY_S84D12sB49NtiIeyw8TAot9Djh61rn9gI7F-jAsLThQ2xBddfbDwqMB_WrDs54xHnl66CC36GGw7wTKNlK-zPKDF_nfZQxjW5EjGd5UO4QoUtj3iMQZTH_hA3ajVXM9ZGrjK0hDgbb-hcPFRN6UgVKkZjtDZxBcCnxIAKSXaTqY9p_1sX-Ku3x_d0KlXmk6ZmUCwD2Dcg"",
                ""expires_in"": 300,
                ""issued_at"":""2023-07-08T02:24:04.535099164Z""
            }
            ";
            yield return @"
            {
                ""manifests"": [
                    {
                        ""digest"": ""sha256:b060fffe8e1561c9c3e6dea6db487b900100fc26830b9ea2ec966c151ab4c020"",
                        ""mediaType"": ""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"": ""amd64"",
                            ""os"": ""linux""
                        },
                        ""size"": 424
                    },
                    {
                        ""digest"": ""sha256:f01654f07625f4a1d40eecfc528693bd734f6c52d9b982da9a963abe3d9de6c8"",
                        ""mediaType"": ""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"": ""arm"",
                            ""os"": ""linux"",
                            ""variant"": ""v7""
                        },
                        ""size"": 424
                    },
                    {
                        ""digest"": ""sha256:fb4a67ec973b2995214edd101e37a83787b175a16750b372789c8f6314dc20ca"",
                        ""mediaType"": ""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"": ""arm64"",
                            ""os"": ""linux"",
                            ""variant"": ""v8""
                        },
                        ""size"": 424
                    },
                    {
                        ""digest"": ""sha256:5a6020490a6bb2b83807200ffb93544553c308eb162fc97db2fd36557403d0d8"",
                        ""mediaType"": ""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"": ""ppc64le"",
                            ""os"": ""linux""
                        },
                        ""size"": 424
                    },
                    {
                        ""digest"": ""sha256:107cc410d683e41f2765125ec3b3aba514025348590539fcc079fa02d54f5708"",
                        ""mediaType"": ""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"": ""s390x"",
                            ""os"": ""linux""
                        },
                        ""size"": 424
                    }
                ],
                ""mediaType"": ""application\/vnd.oci.image.index.v1+json"",
                ""schemaVersion"": 2
            }
            ";
            yield return @"
            {
                ""schemaVersion"": 2,
                ""mediaType"": ""application/vnd.oci.image.manifest.v1+json"",
                ""config"": {
                    ""mediaType"": ""application/vnd.oci.image.config.v1+json"",
                    ""size"": 2299,
                    ""digest"": ""sha256:5a81c4b8502e4979e75bd8f91343b95b0d695ab67f241dbed0d1530a35bde1eb""
                },
                ""layers"": [
                    {
                        ""mediaType"": ""application/vnd.oci.image.layer.v1.tar+gzip"",
                        ""size"": 29533422,
                        ""digest"": ""sha256:3153aa388d026c26a2235e1ed0163e350e451f41a8a313e1804d7e1afb857ab4""
                    }
                ]
            }
            ";
        };

        static void defaultRequestHeaderAssert(string name, string value)
        {
            if (name == "Authorization")
            {
                Assert.Equal($"Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOlt7InR5cGUiOiJyZXBvc2l0b3J5IiwibmFtZSI6ImxpYnJhcnkvdWJ1bnR1IiwiYWN0aW9ucyI6WyJwdWxsIl0sInBhcmFtZXRlcnMiOnsicHVsbF9saW1pdCI6IjEwMCIsInB1bGxfbGltaXRfaW50ZXJ2YWwiOiIyMTYwMCJ9fV0sImF1ZCI6InJlZ2lzdHJ5LmRvY2tlci5pbyIsImV4cCI6MTY4ODc4MzM0NCwiaWF0IjoxNjg4NzgzMDQ0LCJpc3MiOiJhdXRoLmRvY2tlci5pbyIsImp0aSI6ImRja3JfanRpX2FmdFRDNDJSamZjTVdPOE5JQktFZnNxVGVSRT0iLCJuYmYiOjE2ODg3ODI3NDQsInN1YiI6IiJ9.QYbxufuKk5E1RU8wjRo5wrfTQmoNOrqsU553IRZv7pRIqVpWIn3s2vYC-zw7Sx2OriwlJ4n7xc9fkEMXMzAhQ-Bdx05KcqkWvMAGnQKYkUb2XQHVkka18spXfAyZ6BQ-MA3X87op7zbY_S84D12sB49NtiIeyw8TAot9Djh61rn9gI7F-jAsLThQ2xBddfbDwqMB_WrDs54xHnl66CC36GGw7wTKNlK-zPKDF_nfZQxjW5EjGd5UO4QoUtj3iMQZTH_hA3ajVXM9ZGrjK0hDgbb-hcPFRN6UgVKkZjtDZxBcCnxIAKSXaTqY9p_1sX-Ku3x_d0KlXmk6ZmUCwD2Dcg", value);
            }
        };

        var client = new HttpClientMock(getContens(), defaultRequestHeaderAssert);
        using var cs = new CancellationTokenSource(100000);
        var auth = new DockerAuthentication("library", "ubuntu", DockerRegistryAction.All);
        await auth.ExecuteAsync(client, cs.Token);

        // act
        var dockerHub = new DockerHub(auth.CompanyName, auth.ImageName);
        var actual = await dockerHub.GetManifestAsync(client, new ContainerPlatform("amd64", "linux"), "latest", cs.Token);

        // assert
        Assert.Equal("sha256:5a81c4b8502e4979e75bd8f91343b95b0d695ab67f241dbed0d1530a35bde1eb", actual.Content.Config.Digest);
        Assert.Equal("sha256:3153aa388d026c26a2235e1ed0163e350e451f41a8a313e1804d7e1afb857ab4", actual.Content.Layers[0].Digest);
    }

    [Fact]
    [Trait("Category", nameof(DockerHub))]
    public async Task Test002()
    {
        // arrange
        static IEnumerable<string> getContens()
        {
            yield return @"
            {
                ""token"": ""eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOlt7InR5cGUiOiJyZXBvc2l0b3J5IiwibmFtZSI6ImxpYnJhcnkvYWxwaW5lIiwiYWN0aW9ucyI6WyJwdWxsIl0sInBhcmFtZXRlcnMiOnsicHVsbF9saW1pdCI6IjEwMCIsInB1bGxfbGltaXRfaW50ZXJ2YWwiOiIyMTYwMCJ9fV0sImF1ZCI6InJlZ2lzdHJ5LmRvY2tlci5pbyIsImV4cCI6MTY4ODc4NDU5MCwiaWF0IjoxNjg4Nzg0MjkwLCJpc3MiOiJhdXRoLmRvY2tlci5pbyIsImp0aSI6ImRja3JfanRpX2hPVmxuRGhNVUItaHg4Q1NBbTVSYTA3VFJ0UT0iLCJuYmYiOjE2ODg3ODM5OTAsInN1YiI6IiJ9.rm9czBB3yGqNFewB8v9w0RJpwsuSRshCm39cQQa2pr_6wIAMx-lI1mj43sZYhNEtaqiAsZAgIMiS5H3VMFuGZ-Z-zy6xb8IL_2s-YtJo1NSI4rQvxTVtyl1KcxjKLRWywymR-FbGLqIC_Ycgm_oKLa3O7u16M1fLmnllIAHNGa-hSavaVdeY2dyNLeyeGHFrsdTjy29WCJ4ktclCk-NPKQ2YWJ6SEmZynanZ0iRKDe_oRwaZbBl1i_AOURMx2sKV2Wk_Hb_E6q25ACFTp1lwL57RZ1R9r_ZzaYq76Ovw0kq7jCbEBGyBoLKoiEE8rj2eBctfhd3vkhMKYZvEas9o5Q"",
                ""access_token"": ""eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOlt7InR5cGUiOiJyZXBvc2l0b3J5IiwibmFtZSI6ImxpYnJhcnkvYWxwaW5lIiwiYWN0aW9ucyI6WyJwdWxsIl0sInBhcmFtZXRlcnMiOnsicHVsbF9saW1pdCI6IjEwMCIsInB1bGxfbGltaXRfaW50ZXJ2YWwiOiIyMTYwMCJ9fV0sImF1ZCI6InJlZ2lzdHJ5LmRvY2tlci5pbyIsImV4cCI6MTY4ODc4NDU5MCwiaWF0IjoxNjg4Nzg0MjkwLCJpc3MiOiJhdXRoLmRvY2tlci5pbyIsImp0aSI6ImRja3JfanRpX2hPVmxuRGhNVUItaHg4Q1NBbTVSYTA3VFJ0UT0iLCJuYmYiOjE2ODg3ODM5OTAsInN1YiI6IiJ9.rm9czBB3yGqNFewB8v9w0RJpwsuSRshCm39cQQa2pr_6wIAMx-lI1mj43sZYhNEtaqiAsZAgIMiS5H3VMFuGZ-Z-zy6xb8IL_2s-YtJo1NSI4rQvxTVtyl1KcxjKLRWywymR-FbGLqIC_Ycgm_oKLa3O7u16M1fLmnllIAHNGa-hSavaVdeY2dyNLeyeGHFrsdTjy29WCJ4ktclCk-NPKQ2YWJ6SEmZynanZ0iRKDe_oRwaZbBl1i_AOURMx2sKV2Wk_Hb_E6q25ACFTp1lwL57RZ1R9r_ZzaYq76Ovw0kq7jCbEBGyBoLKoiEE8rj2eBctfhd3vkhMKYZvEas9o5Q"",
                ""expires_in"": 300,
                ""issued_at"": ""2023-07-08T02:44:50.168442092Z""}
            ";
            yield return @"
            {
                ""manifests"": [
                    {
                        ""digest"": ""sha256:25fad2a32ad1f6f510e528448ae1ec69a28ef81916a004d3629874104f8a7f70"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"": {
                            ""architecture"": ""amd64"",
                            ""os"": ""linux""
                        },
                        ""size"": 528
                    },
                    {
                        ""digest"": ""sha256:ae30c2911284159e0dc2f244b5e7a8b801b9c9f3449806d6e5591de22b65ce15"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"":
                            {
                                ""architecture"": ""arm"",
                                ""os"": ""linux"",
                                ""variant"": ""v6""
                            },
                        ""size"": 528
                    },
                    {
                        ""digest"": ""sha256:0b75b5bfd67c3ffaee0e951533407f6d45d53d7f4dd139fa0c09747b4849dd5d"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"": {
                            ""architecture"": ""arm"",
                            ""os"": ""linux"",
                            ""variant"": ""v7""
                        },
                        ""size"": 528
                    },
                    {
                        ""digest"": ""sha256:e3bd82196e98898cae9fe7fbfd6e2436530485974dc4fb3b7ddb69134eda2407"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"": {
                            ""architecture"": ""arm64"",
                            ""os"": ""linux"",
                            ""variant"": ""v8""
                        },
                        ""size"": 528
                    },
                    {
                        ""digest"": ""sha256:bd649691cf299c58fec56fb84a5067a915da6915897c6f846a6e317e5ff42a4d"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"": {
                            ""architecture"": ""386"",
                            ""os"": ""linux""
                        },
                        ""size"": 528
                    },
                    {
                        ""digest"": ""sha256:8d42f68528a085fe2d936dcca64c642463744eb47312bb8e95863464550165ca"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"": {
                            ""architecture"": ""ppc64le"",
                            ""os"": ""linux""
                        },
                        ""size"": 528
                    },
                    {
                        ""digest"": ""sha256:579fb3e58c23e1dba58ce7d06a14417954d0daaca4e28fa0358e941895d752f8"",
                        ""mediaType"": ""application\/vnd.docker.distribution.manifest.v2+json"",
                        ""platform"": {
                            ""architecture"": ""s390x"",
                            ""os"":""linux""
                        },
                        ""size"": 528
                    }
                ],
                ""mediaType"": ""application\/vnd.docker.distribution.manifest.list.v2+json"",
                ""schemaVersion"": 2
            }
            ";
            yield return @"
            {
                 ""schemaVersion"": 2,
                 ""mediaType"": ""application/vnd.docker.distribution.manifest.v2+json"",
                 ""config"": {
                      ""mediaType"": ""application/vnd.docker.container.image.v1+json"",
                      ""size"": 1472,
                      ""digest"": ""sha256:c1aabb73d2339c5ebaa3681de2e9d9c18d57485045a4e311d9f8004bec208d67""
                 },
                 ""layers"": [
                      {
                           ""mediaType"": ""application/vnd.docker.image.rootfs.diff.tar.gzip"",
                           ""size"": 3397879,
                           ""digest"": ""sha256:31e352740f534f9ad170f75378a84fe453d6156e40700b882d737a8f4a6988a3""
                      }
                 ]
            }
            ";
        };

        static void defaultRequestHeaderAssert(string name, string value)
        {
            if (name == "Authorization")
            {
                Assert.Equal($"Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOlt7InR5cGUiOiJyZXBvc2l0b3J5IiwibmFtZSI6ImxpYnJhcnkvYWxwaW5lIiwiYWN0aW9ucyI6WyJwdWxsIl0sInBhcmFtZXRlcnMiOnsicHVsbF9saW1pdCI6IjEwMCIsInB1bGxfbGltaXRfaW50ZXJ2YWwiOiIyMTYwMCJ9fV0sImF1ZCI6InJlZ2lzdHJ5LmRvY2tlci5pbyIsImV4cCI6MTY4ODc4NDU5MCwiaWF0IjoxNjg4Nzg0MjkwLCJpc3MiOiJhdXRoLmRvY2tlci5pbyIsImp0aSI6ImRja3JfanRpX2hPVmxuRGhNVUItaHg4Q1NBbTVSYTA3VFJ0UT0iLCJuYmYiOjE2ODg3ODM5OTAsInN1YiI6IiJ9.rm9czBB3yGqNFewB8v9w0RJpwsuSRshCm39cQQa2pr_6wIAMx-lI1mj43sZYhNEtaqiAsZAgIMiS5H3VMFuGZ-Z-zy6xb8IL_2s-YtJo1NSI4rQvxTVtyl1KcxjKLRWywymR-FbGLqIC_Ycgm_oKLa3O7u16M1fLmnllIAHNGa-hSavaVdeY2dyNLeyeGHFrsdTjy29WCJ4ktclCk-NPKQ2YWJ6SEmZynanZ0iRKDe_oRwaZbBl1i_AOURMx2sKV2Wk_Hb_E6q25ACFTp1lwL57RZ1R9r_ZzaYq76Ovw0kq7jCbEBGyBoLKoiEE8rj2eBctfhd3vkhMKYZvEas9o5Q", value);
            }
        };

        var client = new HttpClientMock(getContens(), defaultRequestHeaderAssert);
        using var cs = new CancellationTokenSource(100000);
        var auth = new DockerAuthentication("library", "alpine", DockerRegistryAction.All);
        await auth.ExecuteAsync(client, cs.Token);

        // act
        var dockerHub = new DockerHub(auth.CompanyName, auth.ImageName);
        var actual = await dockerHub.GetManifestAsync(client, new ContainerPlatform("amd64", "linux"), "latest", cs.Token);

        // assert
        Assert.Equal("sha256:c1aabb73d2339c5ebaa3681de2e9d9c18d57485045a4e311d9f8004bec208d67", actual.Content.Config.Digest);
        Assert.Equal("sha256:31e352740f534f9ad170f75378a84fe453d6156e40700b882d737a8f4a6988a3", actual.Content.Layers[0].Digest);
    }
}
