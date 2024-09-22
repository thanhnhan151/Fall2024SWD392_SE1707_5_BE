## 3 Layers architecture

- API : Containing Endpoints coding (Config, Controllers, ...) + Other coding related + Config for Apps + Startup classes (main class || Program class)

- BAL (Business Access Layer) : Containing the #BUSINESS_LOGIC coding and have no direct access to the data in the database + DTOs  ...

- DAL (Data Access Layer) : Containing coding like Repository classes (accessing directly to data in the database via DBContext) + Queries + Unitofwork ...
