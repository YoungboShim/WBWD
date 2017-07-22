outer_width = 20.8;
wire_mount_length = 4;
wire_mount_hole = 3;
stick_width = 6;
stick_thickness = 2;

wire_hole_y = 2;

wall_y = 1.5;
wall_z = stick_thickness;

additional_wire_hole_length = wire_mount_length + 1;

union()
{
    // Main stick and wire hole
    difference()
    {
        cube([2 * (outer_width + wire_mount_length), stick_width, stick_thickness], true);
        union()
        {
            translate([outer_width + wire_mount_hole / 2, 0, 0])
                cube([wire_mount_hole, wire_hole_y, stick_thickness + 1], true);
            translate([-(outer_width + wire_mount_hole / 2), 0, 0])
                cube([wire_mount_hole, wire_hole_y, stick_thickness + 1], true);
        }
    }
    
    // Wall formation
    translate([0, (stick_width - wall_y) / 2, (stick_thickness + wall_z) / 2])
        cube([2 * outer_width, wall_y, wall_z], true);
    translate([0, -(stick_width - wall_y) / 2, (stick_thickness + wall_z) / 2])
        cube([2 * outer_width, wall_y, wall_z], true);
    
    // 2nd wire hole
    difference()
    {
        translate([outer_width + 1.5, stick_width, 0])
            cube([additional_wire_hole_length, stick_width, stick_thickness], true);
        translate([outer_width + wire_mount_hole / 2, stick_width, 0])
                cube([wire_mount_hole, wire_hole_y, stick_thickness + 1], true);
    }
    difference()
    {
        translate([-(outer_width + 1.5), stick_width, 0])
            cube([additional_wire_hole_length, stick_width, stick_thickness], true);
        translate([-(outer_width + wire_mount_hole / 2), stick_width, 0])
                cube([wire_mount_hole, wire_hole_y, stick_thickness + 1], true);
    }
}