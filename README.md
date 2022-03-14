# ShopSRUS.Discount.Api
An API FOr ShopSRUS.Discount.API

<h3> Installation guides </h3>

1. Clone and Build The API

2.  Add  the following fields in your appsettting.config <br>
    `ConnectionStrings: {
    "DiscountConnectionString": "{connectionString}"
  }` <br>
    `DiscountSetting": {
    "Tax": " vat e.g 7.5",
    "UseLowestDiscount": "true"/"false",
    "domain": "supported domain e.g @shopsrus.com"}` <br>
   


3. run the command `update-database` using the package manager console to seed your database <br>

7. navigate to the API using your favourite browser/tools.
