# Hanoi_Rec_graph
Innovated Hanoi recursion Console App with graphic presentation of moving disks. Originally it was implemented in C about ten year ago. Recently got re-implemented in C#.

Enter a height for the Hanoi tower: 5

     |            |            |
     *            |            |
    ***           |            |
   *****          |            |
  *******         |            |
 *********        |            |
-----------  -----------  -----------
     A            B            C


     |            |            |
     |            |            |
    ***           |            |
   *****          |            |
  *******         |            |
 *********        |            *
-----------  -----------  -----------
     A            B            C

Move disk 1 from A to C
..
..
..
..
..
     |            |            |
     |            |            |
     |            |            |
     |            |          *****
     |            |         *******
     *           ***       *********
-----------  -----------  -----------
     A            B            C

Move disk 1 from B to A

     |            |            |
     |            |            |
     |            |           ***
     |            |          *****
     |            |         *******
     *            |        *********
-----------  -----------  -----------
     A            B            C

Move disk 2 from B to C

     |            |            |
     |            |            *
     |            |           ***
     |            |          *****
     |            |         *******
     |            |        *********
-----------  -----------  -----------
     A            B            C

Move disk 1 from A to C

