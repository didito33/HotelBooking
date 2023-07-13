using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Motel" },
                    { 2, "Hostel" },
                    { 3, "Resort" },
                    { 4, "Inn" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria" },
                    { 2, "United States of America" },
                    { 3, "Italy" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 2, 2, "Miami" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 3, 3, "Positano" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, 1, 1, "This is our happy space for your happy days!!!", "https://img.freepik.com/free-photo/colonial-style-house-night-scene_1150-17925.jpg?w=996&t=st=1689255070~exp=1689255670~hmac=dee9381ab587fcbf662cf91576a7a05cca10b06570fa802a29735846d12ffd4b", "Happy Days" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, 2, 2, "This is the comfort deluxe hotel in Miami.", "https://img.freepik.com/premium-photo/luxury-pool-villa-spectacular-contemporary-design-digital-art-real-estate-home-house-property-ge_1258-150753.jpg?w=996", "Comfort Deluxe Hotel" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CategoryId", "CityId", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, 3, 3, "This is our sunny hotel, located on the beach.", "https://img.freepik.com/free-photo/popular-resort-amara-dolce-vita-luxury-hotel-with-pools-water-parks-recreational-area-along-sea-coast-turkey-sunset-tekirova-kemer_146671-18752.jpg?w=996&t=st=1689255117~exp=1689255717~hmac=960e554d1d140cf76b8b039791cdd1d9d86e547089cbbd969898fe46f84e0930", "Sea And Sun" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HotelId", "ImageUrl", "PricePerNight", "RoomCategory" },
                values: new object[] { 1, 2, "Very cozy room with city view and private bathroom.", 1, "https://img.freepik.com/free-photo/3d-rendering-loft-luxury-living-room-with-bookshelf_105762-2104.jpg?w=996&t=st=1689254418~exp=1689255018~hmac=29c24ce3a8eb52db275aa64538a823ac83f6749f3fa0cceed9f9ebd6ef90b846", 50m, 2 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HotelId", "ImageUrl", "PricePerNight", "RoomCategory" },
                values: new object[] { 2, 4, "Very stylish decorated room with a lot of charm.", 2, "https://img.freepik.com/free-photo/mockup-poster-frame-modern-interior-background-with-armchair-accessories-room_41470-5126.jpg?w=826&t=st=1689254644~exp=1689255244~hmac=5993c0b6b8d97d25dee1e977eaf87c3086a5a3425fb2be4ca6efd052305e319c", 80m, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Description", "HotelId", "ImageUrl", "PricePerNight", "RoomCategory" },
                values: new object[] { 3, 2, "Beautifull room with sea view and balcony.", 3, "https://img.freepik.com/free-psd/front-view-room-with-bed-modern-wooden-night-tables-mockup_176382-1962.jpg?w=826&t=st=1689254706~exp=1689255306~hmac=2f4c339bb2b6979caf45d2e93d0bf06246de3dcbc0cc84f2b14be03c30326888", 100m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
