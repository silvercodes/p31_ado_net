using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _08_mig_practice.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cities__3213E83FAF69F688", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__groups__3213E83F8969D34E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__3213E83F4101E16D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schedule_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<byte>(type: "tinyint", nullable: false),
                    item_start = table.Column<TimeOnly>(type: "time", nullable: false),
                    item_end = table.Column<TimeOnly>(type: "time", nullable: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__schedule__3213E83FEB107973", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    slug = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subjects__3213E83FE85E6290", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__branches__3213E83F198A51AD", x => x.id);
                    table.ForeignKey(
                        name: "FK_branches_city",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    hash = table.Column<string>(type: "char(64)", unicode: false, fixedLength: true, maxLength: 64, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F5BDB720C", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_role",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    branch_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__classroo__3213E83F35F8D087", x => x.id);
                    table.ForeignKey(
                        name: "FK_classrooms_branch",
                        column: x => x.branch_id,
                        principalTable: "branches",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "teachers_profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__teachers__3213E83F8D264E9C", x => x.id);
                    table.ForeignKey(
                        name: "FK_teachers_profiles_user",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pairs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pair_date = table.Column<DateOnly>(type: "date", nullable: false),
                    schedule_item_id = table.Column<int>(type: "int", nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: false),
                    theme = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    is_online = table.Column<bool>(type: "bit", nullable: false),
                    classroom_id = table.Column<int>(type: "int", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pairs__3213E83FBCF55EDA", x => x.id);
                    table.ForeignKey(
                        name: "FK_pairs_classroom",
                        column: x => x.classroom_id,
                        principalTable: "classrooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pairs_schedule_item",
                        column: x => x.schedule_item_id,
                        principalTable: "schedule_items",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pairs_subject",
                        column: x => x.subject_id,
                        principalTable: "subjects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pairs_teacher",
                        column: x => x.teacher_id,
                        principalTable: "teachers_profiles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "groups_pairs",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false),
                    pair_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups_pairs", x => new { x.group_id, x.pair_id });
                    table.ForeignKey(
                        name: "FK_groups_pairs_group",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_groups_pairs_pair",
                        column: x => x.pair_id,
                        principalTable: "pairs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_branches_city_id",
                table: "branches",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_classrooms_branch_id",
                table: "classrooms",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_pairs_pair_id",
                table: "groups_pairs",
                column: "pair_id");

            migrationBuilder.CreateIndex(
                name: "IX_pairs_classroom_id",
                table: "pairs",
                column: "classroom_id");

            migrationBuilder.CreateIndex(
                name: "IX_pairs_schedule_item_id",
                table: "pairs",
                column: "schedule_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_pairs_subject_id",
                table: "pairs",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_pairs_teacher_id",
                table: "pairs",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E6164A034882E",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groups_pairs");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "pairs");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropTable(
                name: "schedule_items");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "teachers_profiles");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
