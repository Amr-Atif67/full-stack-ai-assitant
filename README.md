# InventoryHub Full-Stack Application

InventoryHub is a full-stack inventory management application developed using **Blazor WebAssembly** and **ASP.NET Core Minimal API** with **Microsoft Copilot** assistance.

## Project Architecture

```
FullStackApp/
├── ClientApp/                    # Blazor WebAssembly Front-End
│   ├── Models/
│   │   ├── Category.cs           # Category model
│   │   └── Product.cs            # Product model with nested Category
│   ├── Services/
│   │   └── ProductService.cs     # Client API service with in-memory caching
│   ├── Pages/
│   │   └── FetchProducts.razor   # Products UI component
│   └── Program.cs                # Client DI registration
└── ServerApp/                    # ASP.NET Core Minimal API Back-End
    ├── Program.cs                # API endpoints, CORS, & Output Caching
    └── Properties/
        └── launchSettings.json   # Server launch configurations
```

## Key Features & Optimizations

1. **Seamless Integration**: Blazor client fetches product listings from the Minimal API back-end via `HttpClient` over CORS-enabled endpoints.
2. **Standardized JSON Schema**: API returns structured JSON responses with nested `Category` objects:
   ```json
   [
     {
       "id": 1,
       "name": "Laptop",
       "price": 1200.5,
       "stock": 25,
       "category": { "id": 101, "name": "Electronics" }
     }
   ]
   ```
3. **Client-Side Caching**: `ProductService` caches API responses in memory for 2 minutes to eliminate redundant HTTP requests during navigation.
4. **Server Output Caching**: `ServerApp` utilizes ASP.NET Core Output Caching (`AddOutputCache` & `.CacheOutput()`) with a 60-second expiration policy to minimize backend processing load.
5. **Robust Error & Case Handling**: Enabled `PropertyNameCaseInsensitive = true` for deserialization resilience.

## Running the Application

### 1. Start the Back-End API Server
```bash
dotnet run --project FullStackApp/ServerApp/ServerApp.csproj --launch-profile http
```
The API server will run at `http://localhost:5261`. You can test the endpoint directly:
```bash
curl http://localhost:5261/api/productlist
```

### 2. Start the Front-End Client
```bash
dotnet run --project FullStackApp/ClientApp/ClientApp.csproj
```

## Documentation
See [REFLECTION.md](REFLECTION.md) for the detailed capstone reflective summary detailing Copilot's contributions across code generation, debugging, JSON structuring, and performance optimizations.

