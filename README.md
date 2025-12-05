# AozoraPlus

AozoraPlus is a lightweight digital library and REST API gateway built on top of Aozora Bunko (青空文庫). Its goal is to provide an easy-to-use API for developers to browse and integrate Aozora Bunko database into projects. A small React frontend is included to demonstrate the API capabilities.

## Screenshots
![Written works search page](./assets/Screenshot%20from%202025-11-20%2019-01-41.png "Written works page")
![Authors search page](./assets/Screenshot%20from%202025-11-20%2019-04-11.png "Authors search page")
![Book overview page](./assets/Screenshot%20from%202025-11-20%2019-06-42.png "Book overview page")
![Author overview page](./assets/Screenshot%20from%202025-11-20%2019-05-35.png "Author overview page")

## Features
- REST API for authors, written works, and publishers
- Small demo React frontend
- Designed as an REST API gateway for Aozora Bunko (青空文庫) website dataset
- Pagination and filtering support endpoints

## Example endpoints
NOTE: `{{url}}` is `https://localhost:5001`

| Endpoint | Description |
|---|---|
| `{{url}}/` | Welcome message |
| `{{url}}/api/authors?page=1&pageSize=10` | Retrieves 10 authors on page 1 |
| `{{url}}/api/authors/<id>` | Get author by id |
| `{{url}}/api/writtenWorks/?pageSize=25` | Retrieve first 25 written works (page defaults to 1) |
| `{{url}}/api/writtenWorks/<id>` | Retrieve written work by id |
| `{{url}}/api/writtenWorks/?authorId=000879&pageSize=20` | Retrieve first 20 works by a specific author |
| `{{url}}/api/writtenWorks/shinji_shinkana/` | Retrieve 新字新仮名 works (supports pagination) |
| `{{url}}/api/writtenWorks/kyuuji_kyuukana/?authorId=000148` | Retrieve 旧字旧仮名 works filtered by author (supports pagination) |
| `{{url}}/api/writtenWorks/shinji_kyuukana/?id=000148` | Retrieve 新字旧仮名 works (filter by author id, supports pagination) |
| `{{url}}/api/writtenWorks/non_kana` | Retrieve works in non-Japanese scripts (e.g., Latin). Supports authorId filter and pagination. |
| `{{url}}/api/publishers/` | List publishers (supports pagination) |
| `{{url}}/api/publishers/<id>` | Retrieve publisher by id |

## Getting started
### Development setup

#### Backend (root folder)
Start the backend and supporting services with Docker:

```
docker compose up -d --build
```

Services started by Docker:
| Service | Address |
|---|---|
| API | https://localhost:5001, http://localhost:3001 |
| Postgres (main) | localhost:5433 |
| Postgres (Hangfire) | localhost:5434 |

#### Frontend (Client)
From the project root:
```
cd Client
```
Start the frontend (pnpm):
```
pnpm dev
```
Optional: enable TanStack Router route watching
```
pnpm watch-routes
```

#### Testing
Only the API layer is covered by automated tests. Tests run against Postgres TestContainers.

Run tests:
```
# from the repository root
dotnet test

# or run the tests project directly
dotnet test AozoraBunkoDatabase.Tests
```

## Feature Roadmap / Checklist
- ✅ Retrieve authors
- ✅ Retrieve written works
- ✅ Retrieve publishers
- ⬜ Retrieve original source of written works
- ⬜ Login function
- ⬜ Reading / read / plan-to-read / review features
- ⬜ Download ebook (generate EPUB) — planned (Aozora provides text/HTML only)

## License
- Intended as a non-commercial, open developer resource. Add or change license as needed.

Contact notes
- This project is provided as-is to facilitate developer access to Aozora Bunko data. Respect Aozora Bunko terms when using original content.