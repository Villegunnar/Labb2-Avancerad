using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2_Avancerad.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.PersonalId);
                    table.ForeignKey(
                        name: "FK_Personals_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Toys & Computers" },
                    { 2, "Computers, Games & Beauty" },
                    { 3, "Books" },
                    { 4, "Sports & Grocery" },
                    { 5, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Personals",
                columns: new[] { "PersonalId", "Adress", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, "49253 Okey Run, Sylvesterton, China", 5, "Iliana_Kreiger@hotmail.com", "Jayson", "Male", "Collier", "951.492.4453 x57865", 1740.3800000000001 },
                    { 2, "16046 Edgardo Lakes, Port Tomasstad, Belgium", 4, "Tristian.Macejkovic@hotmail.com", "Turner", "Male", "Stoltenberg", "(202) 858-5488", 4836.21 },
                    { 3, "0830 Moses Ridge, New Willafurt, Vietnam", 2, "Amalia.Fadel@gmail.com", "Kathlyn", "Male", "Tremblay", "(310) 916-7522", 5104.8699999999999 },
                    { 4, "508 Olen Square, Leannonmouth, Papua New Guinea", 1, "Raymundo.Dibbert@yahoo.com", "Mckayla", "Male", "Kulas", "1-919-559-1151 x78400", 3533.5599999999999 },
                    { 5, "50401 Heller Shore, South Clovis, Azerbaijan", 1, "Zora.Bartoletti@yahoo.com", "Albin", "Female", "Satterfield", "903.629.6148 x121", 2147.4699999999998 },
                    { 6, "02789 Farrell Gateway, West Georgette, United States of America", 2, "Kennedy.Waters@yahoo.com", "Chris", "Male", "Lakin", "509.783.8130 x14600", 6797.0500000000002 },
                    { 7, "3206 Mayert Extension, Strosinstad, Falkland Islands (Malvinas)", 5, "Dora_Skiles@gmail.com", "Monserrat", "Female", "Yost", "448.411.3624 x341", 4640.7799999999997 },
                    { 8, "61239 Leopold Valley, Chloeberg, Peru", 3, "Dale5@gmail.com", "Dorcas", "Female", "Beer", "1-708-308-6606 x60813", 4826.1599999999999 },
                    { 9, "2487 Clint Cove, West Magnus, Brunei Darussalam", 3, "Aimee_Christiansen@gmail.com", "Adeline", "Male", "Cormier", "808-518-2566", 5813.9899999999998 },
                    { 10, "09404 Hobart Manor, Tressafurt, Madagascar", 5, "Emmitt75@hotmail.com", "Harley", "Female", "Trantow", "636.545.4591 x801", 6210.5299999999997 },
                    { 11, "981 Otha Highway, Bartonfurt, China", 1, "Brielle.Boyle82@gmail.com", "Rebekah", "Female", "Treutel", "(737) 752-8934 x1458", 8293.2099999999991 },
                    { 12, "139 D'Amore Junctions, Bartholomeville, Guyana", 4, "Maxwell27@yahoo.com", "Landen", "Male", "Farrell", "(247) 957-8786 x59580", 1861.5599999999999 },
                    { 13, "39995 Eric Land, Anthonyport, Jamaica", 4, "Luella_Fadel@yahoo.com", "Jimmie", "Female", "Wisoky", "501-390-4319 x3805", 3319.2600000000002 },
                    { 14, "455 Jacey Terrace, Port Blanchemouth, Djibouti", 4, "Urban23@hotmail.com", "Brennon", "Male", "Beer", "(971) 213-8862 x866", 3889.2800000000002 },
                    { 15, "955 Rath Hill, Lednerstad, Iran", 4, "Leland.Hodkiewicz@gmail.com", "Lavonne", "Male", "Kulas", "1-949-702-8545 x2656", 4018.25 },
                    { 16, "014 Hoppe Circle, West Madelynview, Trinidad and Tobago", 4, "Pierre.Heller36@yahoo.com", "Bart", "Male", "Gaylord", "958.323.6335 x593", 9372.2399999999998 },
                    { 17, "745 Alana Pine, East Thelmaland, Fiji", 3, "Wiley85@gmail.com", "Austin", "Female", "Reichel", "350-791-6141", 2984.9699999999998 },
                    { 18, "6264 Kadin Manor, Mattfurt, Vanuatu", 1, "Nels.Schimmel69@yahoo.com", "Ebony", "Female", "O'Kon", "(234) 602-3022 x50027", 9546.0799999999999 },
                    { 19, "70576 Victoria Land, South Helgaville, Colombia", 1, "Arno.Lehner@yahoo.com", "Tierra", "Male", "O'Reilly", "1-411-231-7116", 1485.25 },
                    { 20, "15813 Eino Island, Murrayborough, Ghana", 1, "Gaylord_Bergstrom62@yahoo.com", "Gerhard", "Male", "Gulgowski", "1-374-810-9587", 1232.4000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personals_DepartmentId",
                table: "Personals",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
