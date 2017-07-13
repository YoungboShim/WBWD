// Fan dimensions
fan_width = 17.0;
fan_height = 8.0;
fan_hole_dist = 14.0; // measure
fan_hole_dia = 1.8;

wall_thickness = 1.6;
mount_sheet_thickness = 0.5;

// Tolerance
tol = 0.3;

// Gap between skin and the fan (mm)
gap = 8;

rubber_band_thickness = 2.8;
rubber_band_width = 5;

$fn = 20;

// assembly view
//    translate([0, 0, body_height+tol])
//    slit();
translate([0, fan_gap/2, 0])
rotate([0,0,90])
fan_mount();
translate([0, -fan_gap/2, 0])
fan_mount();
//    rubberband_clamp();

// individual
//slit();

//fan_mount();
//rubberband_clamp();



// Derivated numbers
clamp_width = wall_thickness*2 + rubber_band_thickness;
inner_width = fan_width+tol*2;
outer_width = inner_width + wall_thickness*2;
body_height = mount_sheet_thickness+fan_height;

///////////// Youngbo Added /////////////
// Right part
// Gap between fans' center(mm)
fan_gap = 33;
fan_inner_gap = (fan_gap - outer_width) / 2;

// Bridge thickness between fan mound modules(mm)
bridge_thick = 2;

// Wing hole size(mm)
wing_width = 1.5;
wing_height = outer_width - 2;

// Left or Right
LoR = -1;

// Bridge drawing
translate([0, 0, bridge_thick/2])
cube([outer_width, fan_gap - outer_width, bridge_thick], true);

// Wing drawing
// Top wing
difference(){
    translate([LoR * (outer_width + fan_inner_gap) / 2, fan_gap/2, bridge_thick/2])
    cube([fan_inner_gap, outer_width, bridge_thick], true);
    translate([LoR * (fan_gap/2 - fan_inner_gap/2 + 1), fan_gap/2, bridge_thick/2])
    cube([wing_width, wing_height, bridge_thick*2], true);
}
// Bottom wing
difference(){
    translate([LoR * (outer_width + fan_inner_gap) / 2, -fan_gap/2, bridge_thick/2])
    cube([fan_inner_gap, outer_width, bridge_thick], true);
    translate([LoR * (fan_gap/2 - fan_inner_gap/2 + 1), -fan_gap/2, bridge_thick/2])
    cube([wing_width, wing_height, bridge_thick*2], true);
}

// Wire mount(bottom)
translate([0, (fan_gap + outer_width)/2 + 1.5, 1])
cube([outer_width, 3, 2], center=true);
translate([0, (fan_gap + outer_width)/2 + 2.25, 4])
cube([outer_width, 1.5, 4], center=true);

// Wire mount(top)
translate([0, -(fan_gap + outer_width)/2 - 1.5, 1])
cube([outer_width, 3, 2], center=true);
translate([0, -(fan_gap + outer_width)/2 - 2.25, 4])
cube([outer_width, 1.5, 4], center=true);
///////////// Youngbo Added /////////////

//linear_extrude(body_height)
//translate([outer_width/2+wall_thickness,0,0])
//difference(){
//square([rubber_band_thickness+2*wall_thickness, rubber_band_width+2*wall_thickness], center=true);
//
//square([rubber_band_thickness, rubber_band_width], center=true);
//}
//
//translate([0,0,(body_height)/2-1])
//linear_extrude(2)
//translate([rubber_band_thickness+2*wall_thickness+rubber_band_width/2+2*wall_thickness,0,0])
//square([outer_width/1.8, rubber_band_width+2*wall_thickness], center=true);


module rubberband_clamp()
{
    for(rot = [0, 180])
    {
        rotate([0,0,rot])
        {
            difference()
            {
                union()
                {
                    translate([outer_width/2, -outer_width/2])
                    cube([clamp_width, outer_width, body_height+gap - clamp_width/2]);
                    
                    translate([outer_width/2 + clamp_width/2, -outer_width/2, body_height+gap-clamp_width/2])
                    rotate([-90, 0, 0])
                    cylinder(d=clamp_width, h=outer_width);
                }
                
                
                // rubber band channel
                translate([outer_width/2 + wall_thickness + tol, -outer_width/2])
                cube([rubber_band_thickness - tol*2, outer_width, 2]);
                
                translate([outer_width/2 + wall_thickness, -outer_width/2, 1.5])
                cube([rubber_band_thickness, outer_width, rubber_band_width + tol]);
                
                // air flow gap
                hull()
                {
                    translate([outer_width/2, 0, body_height+gap-4.5])
                    cube([clamp_width*2, 3, 1], center=true);
                    
                    translate([outer_width/2,0,body_height+gap+1])
                    cube([clamp_width*2, outer_width-5, 1], center=true);
                }
            }   
        }
    }
}

module fan_mount()
{
    linear_extrude(height=mount_sheet_thickness)
    fan_mount_profile();


    difference()
    {
        linear_extrude(height=body_height)
        main_body_profile();
        
        // wire channel
        translate([-inner_width/2, inner_width/2-1, 2])
        cube([3, 3, 7]);

    }
    
    
    
    
    module main_body_profile()
    {
        difference()
        {
            union()
            {
                square([outer_width, outer_width], center=true);
            }
            square([inner_width, inner_width], center=true);
        }
    }
    

    module fan_mount_profile()
    {
        difference()
        {
            union()
            {
                for(rot = [0:3])
                {
                    rotate([0,0,rot*90])
                    {
                        // mounting hole columns
                        translate([fan_hole_dist/2, fan_hole_dist/2])
                        circle(d=fan_hole_dia+wall_thickness*2+tol*2);
                        
                        // bridges
                        translate([0, (fan_hole_dist+fan_hole_dia+wall_thickness)/2])
                        square([fan_hole_dist, wall_thickness], center=true);                
                    }
                }
            }


            // mounting holes - inner
            for(rot = [0:3])
                rotate([0,0,rot*90])
                    translate([fan_hole_dist/2, fan_hole_dist/2])
                        circle(d=fan_hole_dia+tol);
        }
     
    }
}


module slit()
{
    intersection()
    {
        union()
        {
            for(i=[-4:4])
            {
                translate([-25, i*3, -1])
                rotate([45, 0, 0])
                cube([50, 0.8, 6]);
            }
        }
        
        cylinder(d=16, h=15);
    }

    difference()
    {
        translate([-outer_width/2+tol,-outer_width/2+tol])
        cube([outer_width-tol*2, outer_width-tol*2, 5]);

        cylinder(d=15, h=6);
    }
}

