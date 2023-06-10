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
        IEnumerable<string> getContens()
        {
            yield return @"
            {
                ""token"": ""eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOltdLCJhdWQiOiJyZWdpc3RyeS5kb2NrZXIuaW8iLCJleHAiOjE2ODYzNTM2NzMsImlhdCI6MTY4NjM1MzM3MywiaXNzIjoiYXV0aC5kb2NrZXIuaW8iLCJqdGkiOiJkY2tyX2p0aV9fQ2ZYcnZYT2tCcU9sYWhEdThLT0dZb0dIOHc9IiwibmJmIjoxNjg2MzUzMDczLCJzdWIiOiIifQ.mqrAkOP2I54dBOqd1pDuyMjLtC-lZDv1HsdG0O4TqkMWoQI_ZfZ7ckvp3_2YdSAnolno3dXEygS1NKbjdUYuc_ShM_q2ngkwLzlI6TvWixU4azx6BJPySdMLmh2rRbXpIkxyNPS9NTXBsqw254mb-omtTnYhu8SfC22n6qSMnpAnmMZLcLaXH2YhaDxeWnaAkBcBc0gnxXjfz_rW6D4KGZRkQPDipqUXni6peGVBuWfIyGzOXBMJiq2pPZ6dpNFzTUW9A-V2Hbe5UMUT9zWR9zDsWgkI6LIiu4MyYbiwFy7im9sT4UEc_iJ-kuZ9IJ8DhEegVnvhK7g__Y-kEyqTtg"",
                ""access_token"": ""eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOltdLCJhdWQiOiJyZWdpc3RyeS5kb2NrZXIuaW8iLCJleHAiOjE2ODYzNTM2NzMsImlhdCI6MTY4NjM1MzM3MywiaXNzIjoiYXV0aC5kb2NrZXIuaW8iLCJqdGkiOiJkY2tyX2p0aV9fQ2ZYcnZYT2tCcU9sYWhEdThLT0dZb0dIOHc9IiwibmJmIjoxNjg2MzUzMDczLCJzdWIiOiIifQ.mqrAkOP2I54dBOqd1pDuyMjLtC-lZDv1HsdG0O4TqkMWoQI_ZfZ7ckvp3_2YdSAnolno3dXEygS1NKbjdUYuc_ShM_q2ngkwLzlI6TvWixU4azx6BJPySdMLmh2rRbXpIkxyNPS9NTXBsqw254mb-omtTnYhu8SfC22n6qSMnpAnmMZLcLaXH2YhaDxeWnaAkBcBc0gnxXjfz_rW6D4KGZRkQPDipqUXni6peGVBuWfIyGzOXBMJiq2pPZ6dpNFzTUW9A-V2Hbe5UMUT9zWR9zDsWgkI6LIiu4MyYbiwFy7im9sT4UEc_iJ-kuZ9IJ8DhEegVnvhK7g__Y-kEyqTtg"",
                ""expires_in"": 300,
                ""issued_at"": ""2023-06-09T23:29:33.354485697Z""
            } 
            ";
            yield return @"
            {
                ""manifests"": [
                    {
                        ""digest"":""sha256:2fdb1cf4995abb74c035e5f520c0f3a46f12b3377a59e86ecca66d8606ad64f9"",
                        ""mediaType"":""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"":""amd64"",
                            ""os"":""linux""
                        },
                        ""size"":424
                    },
                    {
                        ""digest"":""sha256:c80ed91cdc47229010c4f34f96c3442bc02dca260d0bf26f6c4b047ea7d11cf2"",
                        ""mediaType"":""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"":""arm"",
                            ""os"":""linux"",
                            ""variant"":""v7""
                        },
                        ""size"":424
                    },
                    {
                        ""digest"":""sha256:77bdd217935d10f0e753ed84118e9b11d3ab0a66a82bdf322087354ccd833733"",
                        ""mediaType"":""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"":""arm64"",
                            ""os"":""linux"",
                            ""variant"":""v8""
                        },
                        ""size"":424
                    },
                    {
                        ""digest"":""sha256:268686ba2c6284461cae1642d9d055e51b16f8e711d49b34638146b78050f5a0"",
                        ""mediaType"":""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"":""ppc64le"",
                            ""os"":""linux""
                        },
                        ""size"":424
                    },
                    {
                        ""digest"":""sha256:b0b966f885ea29d809d03d027c3d21182676380b241c3a271aa83f8e9d7bac06"",
                        ""mediaType"":""application\/vnd.oci.image.manifest.v1+json"",
                        ""platform"": {
                            ""architecture"":""s390x"",
                            ""os"":""linux""
                        },
                        ""size"":424
                    }
                ],
                ""mediaType"":""application\/vnd.oci.image.index.v1+json"",
                ""schemaVersion"":2
            }
            ";
            yield return @"
            {
                ""schemaVersion"": 2,
                ""mediaType"": ""application/vnd.oci.image.manifest.v1+json"",
                ""config"": {
                    ""mediaType"": ""application/vnd.oci.image.config.v1+json"",
                    ""size"": 2297,
                    ""digest"": ""sha256:1f6ddc1b2547b2e38dc25b265ac585238a3c23da63976722864dab2a069c74f4""
                },
                ""layers"": [
                    {
                        ""mediaType"": ""application/vnd.oci.image.layer.v1.tar+gzip"",
                        ""size"": 29534702,
                        ""digest"": ""sha256:837dd4791cdc6f670708c3a570b72169263806d7ccc2783173b9e88f94878271""
                    }
                ]
            }
            ";
        };
        var index = 0;
        void defaultRequestHeaderAssert(string name, string value)
        {
            if (index == 0)
            {
                Assert.Equal("Authorization", name);
                Assert.Equal($"Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsIng1YyI6WyJNSUlDK1RDQ0FwK2dBd0lCQWdJQkFEQUtCZ2dxaGtqT1BRUURBakJHTVVRd1FnWURWUVFERXp0U1RVbEdPbEZNUmpRNlEwZFFNenBSTWtWYU9sRklSRUk2VkVkRlZUcFZTRlZNT2taTVZqUTZSMGRXV2pwQk5WUkhPbFJMTkZNNlVVeElTVEFlRncweU16QXhNRFl3TkRJM05EUmFGdzB5TkRBeE1qWXdOREkzTkRSYU1FWXhSREJDQmdOVkJBTVRPME5EVlVZNlNqVkhOanBGUTFORU9rTldSRWM2VkRkTU1qcEtXa1pST2xOTk0wUTZXRmxQTkRwV04wTkhPa2RHVjBJNldsbzFOam8wVlVSRE1JSUJJakFOQmdrcWhraUc5dzBCQVFFRkFBT0NBUThBTUlJQkNnS0NBUUVBek4wYjBqN1V5L2FzallYV2gyZzNxbzZKaE9rQWpYV0FVQmNzSHU2aFlaUkZMOXZlODEzVEI0Y2w4UWt4Q0k0Y1VnR0duR1dYVnhIMnU1dkV0eFNPcVdCcnhTTnJoU01qL1ZPKzYvaVkrOG1GRmEwR2J5czF3VDVjNlY5cWROaERiVGNwQXVYSjFSNGJLdSt1VGpVS0VIYXlqSFI5TFBEeUdnUC9ubUFadk5PWEdtclNTSkZJNnhFNmY3QS8rOVptcWgyVlRaQlc0cXduSnF0cnNJM2NveDNQczMwS2MrYUh3V3VZdk5RdFNBdytqVXhDVVFoRWZGa0lKSzh6OVdsL1FjdE9EcEdUeXNtVHBjNzZaVEdKWWtnaGhGTFJEMmJQTlFEOEU1ZWdKa2RQOXhpaW5sVGx3MjBxWlhVRmlqdWFBcndOR0xJbUJEWE0wWlI1YzVtU3Z3SURBUUFCbzRHeU1JR3ZNQTRHQTFVZER3RUIvd1FFQXdJSGdEQVBCZ05WSFNVRUNEQUdCZ1JWSFNVQU1FUUdBMVVkRGdROUJEdERRMVZHT2tvMVJ6WTZSVU5UUkRwRFZrUkhPbFEzVERJNlNscEdVVHBUVFRORU9saFpUelE2VmpkRFJ6cEhSbGRDT2xwYU5UWTZORlZFUXpCR0JnTlZIU01FUHpBOWdEdFNUVWxHT2xGTVJqUTZRMGRRTXpwUk1rVmFPbEZJUkVJNlZFZEZWVHBWU0ZWTU9rWk1WalE2UjBkV1dqcEJOVlJIT2xSTE5GTTZVVXhJU1RBS0JnZ3Foa2pPUFFRREFnTklBREJGQWlFQW1RNHhsQXZXVlArTy9hNlhDU05pYUFYRU1Bb1RQVFRYRWJYMks2RVU4ZTBDSUg0QTAwSVhtUndjdGtEOHlYNzdkTVoyK0pEY1FGdDFxRktMZFR5SnVzT1UiXX0.eyJhY2Nlc3MiOltdLCJhdWQiOiJyZWdpc3RyeS5kb2NrZXIuaW8iLCJleHAiOjE2ODYzNTM2NzMsImlhdCI6MTY4NjM1MzM3MywiaXNzIjoiYXV0aC5kb2NrZXIuaW8iLCJqdGkiOiJkY2tyX2p0aV9fQ2ZYcnZYT2tCcU9sYWhEdThLT0dZb0dIOHc9IiwibmJmIjoxNjg2MzUzMDczLCJzdWIiOiIifQ.mqrAkOP2I54dBOqd1pDuyMjLtC-lZDv1HsdG0O4TqkMWoQI_ZfZ7ckvp3_2YdSAnolno3dXEygS1NKbjdUYuc_ShM_q2ngkwLzlI6TvWixU4azx6BJPySdMLmh2rRbXpIkxyNPS9NTXBsqw254mb-omtTnYhu8SfC22n6qSMnpAnmMZLcLaXH2YhaDxeWnaAkBcBc0gnxXjfz_rW6D4KGZRkQPDipqUXni6peGVBuWfIyGzOXBMJiq2pPZ6dpNFzTUW9A-V2Hbe5UMUT9zWR9zDsWgkI6LIiu4MyYbiwFy7im9sT4UEc_iJ-kuZ9IJ8DhEegVnvhK7g__Y-kEyqTtg", value);
            }
            ++index;
        };
        var client = new HttpClientMock(getContens(), defaultRequestHeaderAssert);
        using var cs = new CancellationTokenSource(100000);
        var auth = new DockerAuthentication("library", "ubuntu", DockerRegistryAction.All);
        await auth.ExecuteAsync(client, cs.Token);

        // act
        var actual = await DockerHub.GetConfigAsync(client, auth, new ContainerPlatform("amd64", "linux"), "latest", cs.Token);
        await actual.PullAsync(client, new DirectoryInfo(@"C:\Users\10087901428\Desktop\temp\temp"), cs.Token);

        // assert

    }
}
