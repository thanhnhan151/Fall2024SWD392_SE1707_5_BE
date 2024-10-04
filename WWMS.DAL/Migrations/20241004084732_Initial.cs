using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    role = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    profile_image_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    account_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehouse_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    location_address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    current_occupancy = table.Column<int>(type: "int", nullable: true),
                    manager_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    climate_control = table.Column<bool>(type: "bit", nullable: true),
                    security_level = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    emergency_contact = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    operational_hours = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    year_built = table.Column<int>(type: "int", nullable: true),
                    warehouse_area = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    fire_safety_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    insurance_coverage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    number_of_employees = table.Column<int>(type: "int", nullable: true),
                    inspection_frequency = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("warehouse_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Wine_Category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    region = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    grape_variety = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    color = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    aroma_profile = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    flavor_profile = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    production_method = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ideal_serving_temp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    food_pairing = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ageing_potential = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    bottle_shape = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sugar_content = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tannin_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    acidity_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    vineyard = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("wine_category_id_primary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Audit_Log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    action_type = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    action_description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    performed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ip_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    device_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    response_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    duration_ms = table.Column<int>(type: "int", nullable: true),
                    request_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    response_time = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    error_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    response_size = table.Column<long>(type: "bigint", nullable: true),
                    session_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("audit_log_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Check_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    requested_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    request_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    total_items = table.Column<int>(type: "int", nullable: true),
                    items_checked = table.Column<int>(type: "int", nullable: true),
                    discrepancies = table.Column<int>(type: "int", nullable: true),
                    checker_assigned = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    expected_completion_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    request_priority = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    assigned_team = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    check_purpose = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    attachments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    audit_reference = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventory_check_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign_8",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Wine",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wine_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    vintage = table.Column<int>(type: "int", nullable: false),
                    alcohol_content = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    bottle_size = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    available_stock = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    label_image_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    wine_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    bottle_weight = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    acidity_level = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    tannin_content = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sweetness_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    wine_ageing_time = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    harvest_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fermentation_process = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    wine_category_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("wine_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "wine_category_foreign",
                        column: x => x.wine_category_id,
                        principalTable: "Wine_Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Check_Request_Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    warehouse_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    requested_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    request_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    total_items = table.Column<int>(type: "int", nullable: true),
                    items_checked = table.Column<int>(type: "int", nullable: true),
                    discrepancies = table.Column<int>(type: "int", nullable: true),
                    checker_assigned = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    expected_completion_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false),
                    inventory_check_request_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("check_request_warehouse_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "inventory_check_request_foreign_2",
                        column: x => x.inventory_check_request_id,
                        principalTable: "Inventory_Check_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "warehouse_foreign",
                        column: x => x.warehouse_id,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Export_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    export_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    destination_address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    total_quantity = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    shipping_company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    shipping_tracking_number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    total_value = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    customs_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    expected_delivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    insurance_coverage = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    delivery_terms = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    packaging_instructions = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fragile_items = table.Column<bool>(type: "bit", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("export_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign_2",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_foreign_2",
                        column: x => x.wine_id,
                        principalTable: "Wine",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Import_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    supplier = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    import_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    total_quantity = table.Column<int>(type: "int", nullable: true),
                    total_value = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    warehouse_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    transport_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    customs_clearance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    delivery_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    expected_arrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    insurance_provider = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    shipping_method = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tax_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    wine_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("import_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "user_foreign_4",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_foreign",
                        column: x => x.wine_id,
                        principalTable: "Wine",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Additional_Import_Request",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    requester_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    supplier = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    import_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    additional_quantity = table.Column<int>(type: "int", nullable: true),
                    total_value = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    warehouse_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    transport_details = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    export_request_id = table.Column<long>(type: "bigint", nullable: false),
                    inventory_check_request_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    import_request_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("additional_import_request_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "export_request_foreign_3",
                        column: x => x.export_request_id,
                        principalTable: "Export_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "import_request_foreign_3",
                        column: x => x.import_request_id,
                        principalTable: "Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "inventory_check_request_foreign_3",
                        column: x => x.inventory_check_request_id,
                        principalTable: "Inventory_Check_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_foreign_5",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Wine_Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wine_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    wine_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    warehouse_location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    section = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    rack = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    storage_temperature = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    humidity_level = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    wine_condition = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    arrival_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    departure_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_inspection_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inspection_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    handling_instructions = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false),
                    import_request_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("wine_warehouse_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "import_request_foreign_2",
                        column: x => x.import_request_id,
                        principalTable: "Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "warehouse_foreign_2",
                        column: x => x.warehouse_id,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_foreign_3",
                        column: x => x.wine_id,
                        principalTable: "Wine",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    import_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    items_imported = table.Column<int>(type: "int", nullable: true),
                    discrepancies_found = table.Column<int>(type: "int", nullable: true),
                    report_prepared_by = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prepared_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    report_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    file_attachment = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    sign_off_by = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    review_comments = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    final_approval_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    supplier_feedback = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    damage_report = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    import_request_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    export_request_id = table.Column<long>(type: "bigint", nullable: true),
                    inventory_check_request_id = table.Column<long>(type: "bigint", nullable: true),
                    additional_import_request_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("report_id_primary", x => x.id);
                    table.ForeignKey(
                        name: "additional_import_request_foreign",
                        column: x => x.additional_import_request_id,
                        principalTable: "Additional_Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "export_request_foreign",
                        column: x => x.export_request_id,
                        principalTable: "Export_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "import_request_foreign",
                        column: x => x.import_request_id,
                        principalTable: "Import_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "inventory_check_request_foreign",
                        column: x => x.inventory_check_request_id,
                        principalTable: "Inventory_Check_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_foreign_6",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Export_Wine_Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    export_request_id = table.Column<long>(type: "bigint", nullable: false),
                    wine_warehouse_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Export_W__3213E83FDCC5E67C", x => x.id);
                    table.ForeignKey(
                        name: "export_request_foreign_2",
                        column: x => x.export_request_id,
                        principalTable: "Export_Request",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wine_warehouse_foreign",
                        column: x => x.wine_warehouse_id,
                        principalTable: "Wine_Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_export_request_id",
                table: "Additional_Import_Request",
                column: "export_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_import_request_id",
                table: "Additional_Import_Request",
                column: "import_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_inventory_check_request_id",
                table: "Additional_Import_Request",
                column: "inventory_check_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Additional_Import_Request_user_id",
                table: "Additional_Import_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Log_user_id",
                table: "Audit_Log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Check_Request_Warehouse_inventory_check_request_id",
                table: "Check_Request_Warehouse",
                column: "inventory_check_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Check_Request_Warehouse_warehouse_id",
                table: "Check_Request_Warehouse",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Request_user_id",
                table: "Export_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Request_wine_id",
                table: "Export_Request",
                column: "wine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Wine_Warehouse_export_request_id",
                table: "Export_Wine_Warehouse",
                column: "export_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Wine_Warehouse_wine_warehouse_id",
                table: "Export_Wine_Warehouse",
                column: "wine_warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Import_Request_user_id",
                table: "Import_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Import_Request_wine_id",
                table: "Import_Request",
                column: "wine_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Check_Request_user_id",
                table: "Inventory_Check_Request",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_user_id",
                table: "Report",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__42A76907FBF5270C",
                table: "Report",
                column: "export_request_id",
                unique: true,
                filter: "[export_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__554DA09A96662158",
                table: "Report",
                column: "additional_import_request_id",
                unique: true,
                filter: "[additional_import_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__8099F7E53B1391DC",
                table: "Report",
                column: "inventory_check_request_id",
                unique: true,
                filter: "[inventory_check_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Report__C75CF497B655D9AD",
                table: "Report",
                column: "import_request_id",
                unique: true,
                filter: "[import_request_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_wine_category_id",
                table: "Wine",
                column: "wine_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_Warehouse_import_request_id",
                table: "Wine_Warehouse",
                column: "import_request_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_Warehouse_warehouse_id",
                table: "Wine_Warehouse",
                column: "warehouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wine_Warehouse_wine_id",
                table: "Wine_Warehouse",
                column: "wine_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit_Log");

            migrationBuilder.DropTable(
                name: "Check_Request_Warehouse");

            migrationBuilder.DropTable(
                name: "Export_Wine_Warehouse");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Wine_Warehouse");

            migrationBuilder.DropTable(
                name: "Additional_Import_Request");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Export_Request");

            migrationBuilder.DropTable(
                name: "Import_Request");

            migrationBuilder.DropTable(
                name: "Inventory_Check_Request");

            migrationBuilder.DropTable(
                name: "Wine");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Wine_Category");
        }
    }
}
