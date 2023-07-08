# ContainerDownloader

## How to use

```
var client = new HttpClient();
using var cs = new CancellationTokenSource(100000);
var auth = new DockerAuthentication("library", "alpine", DockerRegistryAction.All);
await auth.ExecuteAsync(client, cs.Token);
var dockerHub = new DockerHub(auth.CompanyName, auth.ImageName);
var manifest = await dockerHub.GetManifestAsync(client, new ContainerPlatform("amd64", "linux"), "latest", cs.Token);
await manifest.PullContainerAsync(client, new DirectoryInfo(@"C:\"), cs.Token);
```
