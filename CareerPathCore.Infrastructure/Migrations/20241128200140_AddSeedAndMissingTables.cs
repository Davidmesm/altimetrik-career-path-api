using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CareerPathCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedAndMissingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNewUser",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Validation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ValidationTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobLevelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRoles_JobAreas_JobAreaId",
                        column: x => x.JobAreaId,
                        principalTable: "JobAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobRoles_JobLevels_JobLevelId",
                        column: x => x.JobLevelId,
                        principalTable: "JobLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "text", nullable: false),
                    CurrentJobRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    FutureJobRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_JobRoles_CurrentJobRoleId",
                        column: x => x.CurrentJobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_JobRoles_FutureJobRoleId",
                        column: x => x.FutureJobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsValidated = table.Column<bool>(type: "boolean", nullable: false),
                    ValidtionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardSkills_SkillLevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HardSkills_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HardSkills_Validation_ValidtionId",
                        column: x => x.ValidtionId,
                        principalTable: "Validation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoftSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsValidated = table.Column<bool>(type: "boolean", nullable: false),
                    ValidtionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftSkills_SkillLevel_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftSkills_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftSkills_Validation_ValidtionId",
                        column: x => x.ValidtionId,
                        principalTable: "Validation",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "EducationLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("87aafb4c-42e7-4bdc-aada-7d042b1c9678"), "Doctorate (Ph.D.)" },
                    { new Guid("90b06b5f-9c96-4616-a8cb-1225f56a668d"), "High School Diploma or Equivalent" },
                    { new Guid("93d218a3-b378-4037-b2bc-cd4370ee630c"), "Professional Certification" },
                    { new Guid("bca3c81f-3a55-4a20-89e4-7ad434e54540"), "Master's Degree" },
                    { new Guid("c352b73c-7e12-43a8-9fb1-8e3a663e4795"), "No Formal Education" },
                    { new Guid("ca96a6fe-5ca4-48e1-b5a0-345b4794c7ee"), "Bachelor's Degree" },
                    { new Guid("f5c7c475-b7ad-44a1-ad5a-d1803f34cc0b"), "Associate's Degree" }
                });

            migrationBuilder.InsertData(
                table: "JobAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c7baf1d-a54b-493e-be77-9356c30133ca"), "AI Engineering" },
                    { new Guid("2d289858-8a8c-4a3c-a6ab-dc87627fc501"), "Automation Testing" },
                    { new Guid("3416bc50-eb9c-4185-833e-bf7fd8eedb61"), "DevOps/SRE/Infra" },
                    { new Guid("364681f4-48ed-4db3-9883-b4757ce482bc"), "Fullstack Engineering" },
                    { new Guid("40421aca-5df8-494f-a335-56549630e530"), "Data Science" },
                    { new Guid("41859a58-54a1-4795-9d42-fb7946990456"), "Data Engineering" },
                    { new Guid("48dd9750-b3ef-4ac6-bb6a-cff1e0746a20"), "Manual Testing" },
                    { new Guid("96143222-c40e-4d26-bf27-da99fdfe3137"), "Backend Engineering" },
                    { new Guid("c5e9a7d5-8d03-47dd-918f-23ca0c85235d"), "Mobile Engineering" },
                    { new Guid("df90241d-1427-4b93-9a98-bd48668b467b"), "Frontend Engineering" },
                    { new Guid("e8142c80-9123-4b5a-b454-b3f687669d3c"), "UX/UI Design" }
                });

            migrationBuilder.InsertData(
                table: "JobLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071"), "Senior" },
                    { new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c"), "Architect" },
                    { new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f"), "Junior" },
                    { new Guid("95f75860-d1fd-4956-855c-21fb64284caf"), "Mid" },
                    { new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197"), "Lead" }
                });

            migrationBuilder.InsertData(
                table: "JobRoles",
                columns: new[] { "Id", "JobAreaId", "JobLevelId" },
                values: new object[,]
                {
                    { new Guid("054e138b-62cc-4602-b629-b480e4941552"), new Guid("2d289858-8a8c-4a3c-a6ab-dc87627fc501"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("067f23ab-7d41-47a3-a2df-d230e77da5d8"), new Guid("e8142c80-9123-4b5a-b454-b3f687669d3c"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("0d0878aa-6b59-45c5-b0d8-45be1165cc42"), new Guid("41859a58-54a1-4795-9d42-fb7946990456"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("137d44f9-0e1c-4e2d-a34a-3392ab1a7463"), new Guid("41859a58-54a1-4795-9d42-fb7946990456"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("13e4db86-9ad6-4e8e-ae64-7ea59b92d5cf"), new Guid("e8142c80-9123-4b5a-b454-b3f687669d3c"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("176671f3-68d5-4573-88a7-aae2892ba269"), new Guid("364681f4-48ed-4db3-9883-b4757ce482bc"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("19da607b-4368-4824-9fd2-5b6e1b6f3a84"), new Guid("48dd9750-b3ef-4ac6-bb6a-cff1e0746a20"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("20badd08-5ede-46dc-a4b1-1b134b3c71ef"), new Guid("96143222-c40e-4d26-bf27-da99fdfe3137"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("2707a397-3893-479d-9ac1-25d850059bee"), new Guid("40421aca-5df8-494f-a335-56549630e530"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("2791f705-a407-492b-a04f-42d70598dba9"), new Guid("3416bc50-eb9c-4185-833e-bf7fd8eedb61"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("318d1c22-3d7c-4516-a4c1-bef951f2e1a7"), new Guid("48dd9750-b3ef-4ac6-bb6a-cff1e0746a20"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("38178e08-9cef-4803-93a6-60095c21be05"), new Guid("364681f4-48ed-4db3-9883-b4757ce482bc"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("3f06e4cb-012f-4cba-9623-fce8b9f21969"), new Guid("40421aca-5df8-494f-a335-56549630e530"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("4219939f-4065-45fc-a17a-31a774300d15"), new Guid("0c7baf1d-a54b-493e-be77-9356c30133ca"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("446dfbac-29f2-4df4-b05b-ac1641904347"), new Guid("3416bc50-eb9c-4185-833e-bf7fd8eedb61"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("44abc3ce-f4e1-4f22-863e-fbf8ee0a696a"), new Guid("96143222-c40e-4d26-bf27-da99fdfe3137"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("44e852bc-52c0-40ee-90db-1797d3338b1c"), new Guid("96143222-c40e-4d26-bf27-da99fdfe3137"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("4ed640a9-099b-4468-b5a1-79da4505e051"), new Guid("364681f4-48ed-4db3-9883-b4757ce482bc"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("53a23ffc-fa52-47a0-9fac-cbd69e5d1898"), new Guid("41859a58-54a1-4795-9d42-fb7946990456"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("64209e5a-d232-4759-b8ff-15d64d77afd9"), new Guid("364681f4-48ed-4db3-9883-b4757ce482bc"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("6a94a84b-7dba-4bc9-bb16-84f8505bcf22"), new Guid("e8142c80-9123-4b5a-b454-b3f687669d3c"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("6aa646f9-0751-41bb-8c0f-7744113fb0ec"), new Guid("df90241d-1427-4b93-9a98-bd48668b467b"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("770aba77-fce1-4b3d-b28d-9b57d09ed803"), new Guid("96143222-c40e-4d26-bf27-da99fdfe3137"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("81642ba0-f6ae-4a11-85bc-2e4226e3f4aa"), new Guid("3416bc50-eb9c-4185-833e-bf7fd8eedb61"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("82c5bfcf-a2b3-4a27-b3da-55dbd2026dee"), new Guid("40421aca-5df8-494f-a335-56549630e530"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("8b4f2618-eafe-4de9-9c29-3e21148450fa"), new Guid("c5e9a7d5-8d03-47dd-918f-23ca0c85235d"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("8b77add5-e75a-4fe3-a137-f123116af0d9"), new Guid("3416bc50-eb9c-4185-833e-bf7fd8eedb61"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("8f9f98a3-a950-4cb5-8f3a-c775addc1fb3"), new Guid("0c7baf1d-a54b-493e-be77-9356c30133ca"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("8fbc6740-9b73-424b-9208-9d9ccb039081"), new Guid("0c7baf1d-a54b-493e-be77-9356c30133ca"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("93ea795a-974d-4b11-a85a-aa01dfa7aed1"), new Guid("c5e9a7d5-8d03-47dd-918f-23ca0c85235d"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("9401cedd-3c81-44ee-80f6-5c71c0d57bf5"), new Guid("3416bc50-eb9c-4185-833e-bf7fd8eedb61"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("99491640-52bb-414b-89aa-1c2237e9882c"), new Guid("c5e9a7d5-8d03-47dd-918f-23ca0c85235d"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("a04b77bc-4f4b-4565-be88-3ea714593e87"), new Guid("364681f4-48ed-4db3-9883-b4757ce482bc"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("a717fcf2-c14f-4c73-be2d-bd587c6f0238"), new Guid("40421aca-5df8-494f-a335-56549630e530"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("a91f398e-f29d-4af6-b86c-23762eee1885"), new Guid("c5e9a7d5-8d03-47dd-918f-23ca0c85235d"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("b16bf367-4ab2-4f5c-925c-70f5ea9cc4ad"), new Guid("e8142c80-9123-4b5a-b454-b3f687669d3c"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("b68e12d7-8148-4a15-89f2-9659ea91000a"), new Guid("48dd9750-b3ef-4ac6-bb6a-cff1e0746a20"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("b70da789-9dad-411e-b9a6-a8ec6be7d095"), new Guid("df90241d-1427-4b93-9a98-bd48668b467b"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("ba3a8eef-bc71-4aaa-a318-c3f5a18b7f74"), new Guid("df90241d-1427-4b93-9a98-bd48668b467b"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("bdfc9a95-9da7-4540-9311-381fe535d606"), new Guid("c5e9a7d5-8d03-47dd-918f-23ca0c85235d"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("bedd8ad6-b58b-42d2-b975-98d6f0797ccb"), new Guid("2d289858-8a8c-4a3c-a6ab-dc87627fc501"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("bf33e555-bfb4-431a-beae-06223bc6cf22"), new Guid("48dd9750-b3ef-4ac6-bb6a-cff1e0746a20"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("c27c793f-ea43-4190-8fc1-49d71081c70c"), new Guid("df90241d-1427-4b93-9a98-bd48668b467b"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("d1028d05-4757-44f3-9948-3358e64271b7"), new Guid("41859a58-54a1-4795-9d42-fb7946990456"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("d14dd217-6bb9-4267-835b-01164e1acd8c"), new Guid("48dd9750-b3ef-4ac6-bb6a-cff1e0746a20"), new Guid("2968646f-8af6-4385-8ffb-f480f91ce71f") },
                    { new Guid("d5f97718-196f-4961-b5c9-a165798a179b"), new Guid("2d289858-8a8c-4a3c-a6ab-dc87627fc501"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("da6884a7-f348-47ce-b954-004e171cf3c5"), new Guid("41859a58-54a1-4795-9d42-fb7946990456"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") },
                    { new Guid("de407f9e-63d0-4ad0-a691-fb672bec85bb"), new Guid("0c7baf1d-a54b-493e-be77-9356c30133ca"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("e10ebb02-829a-4b82-968f-58c8cae88b34"), new Guid("e8142c80-9123-4b5a-b454-b3f687669d3c"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("ebfe74a2-7cd0-48e5-96d9-80e2b05c8122"), new Guid("2d289858-8a8c-4a3c-a6ab-dc87627fc501"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("ecdea35d-131c-4e85-a386-13338713e70f"), new Guid("2d289858-8a8c-4a3c-a6ab-dc87627fc501"), new Guid("95f75860-d1fd-4956-855c-21fb64284caf") },
                    { new Guid("f3d84dd5-96f2-4e26-97b3-95c2668170e5"), new Guid("40421aca-5df8-494f-a335-56549630e530"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("f57d72d1-ac23-4ce9-a801-f66075e93bd1"), new Guid("df90241d-1427-4b93-9a98-bd48668b467b"), new Guid("0ffa6c99-d4df-4f1b-8be4-ac4e7f45a071") },
                    { new Guid("f702a4ba-97e1-4947-9582-6183e64cbb24"), new Guid("96143222-c40e-4d26-bf27-da99fdfe3137"), new Guid("1d603409-c561-41c8-ab04-8d389ed7fa4c") },
                    { new Guid("fbd1ffeb-aebb-4448-8b9e-e20260470487"), new Guid("0c7baf1d-a54b-493e-be77-9356c30133ca"), new Guid("d86b90e1-7de8-44f8-b56b-c83b558fa197") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HardSkills_SkillLevelId",
                table: "HardSkills",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HardSkills_UserProfileId",
                table: "HardSkills",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_HardSkills_ValidtionId",
                table: "HardSkills",
                column: "ValidtionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRoles_JobAreaId",
                table: "JobRoles",
                column: "JobAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_JobRoles_JobLevelId",
                table: "JobRoles",
                column: "JobLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkills_SkillLevelId",
                table: "SoftSkills",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkills_UserProfileId",
                table: "SoftSkills",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkills_ValidtionId",
                table: "SoftSkills",
                column: "ValidtionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CurrentJobRoleId",
                table: "UserProfiles",
                column: "CurrentJobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_EducationLevelId",
                table: "UserProfiles",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_FutureJobRoleId",
                table: "UserProfiles",
                column: "FutureJobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardSkills");

            migrationBuilder.DropTable(
                name: "SoftSkills");

            migrationBuilder.DropTable(
                name: "SkillLevel");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Validation");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "JobRoles");

            migrationBuilder.DropTable(
                name: "JobAreas");

            migrationBuilder.DropTable(
                name: "JobLevels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsNewUser",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
