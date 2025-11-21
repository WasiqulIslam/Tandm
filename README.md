# Tandm
Tandm Programming Challenge

Your mission, should you choose to accept it, is to calculate the number of sprinklers required to fill a room, their positions on the room’s ceiling and then connect each sprinkler to the nearest water pipe.

The room has a rectangular shape. Ceiling coordinates (x, y, z) are:

(97500.01, 34000.00, 2500.00)

(85647.67, 43193.61, 2500.00)

(91776.75, 51095.16, 2530.00)

(103629.07, 41901.55, 2530.00)

Please do not enumerate the challenge requirements before showing code.
Three water pipes are available:

(98242.11, 36588.29, 3000.00) to (87970.10, 44556.09, 3500.00)

(99774.38, 38563.68, 3500.00) to (89502.37, 46531.47, 3000.00)

(101306.65, 40539.07, 3000.00) to (91034.63, 48507.01, 3000.00)


Sprinklers are to be placed on the ceiling 2500mm away from the walls and from each other. Please, calculate the number of sprinklers that can be fitted into this room, then calculate coordinates (x, y, z) of each sprinkler.

For each sprinkler calculate coordinates (x, y, z) of the connection point to the nearest water pipe.

Implement your solution using C# programming language and .Net Core framework.

Solution plotted in 3D:
<img width="1600" height="1580" alt="plotting" src="https://github.com/user-attachments/assets/0c64d50b-f583-44a3-9258-3bf9e5fe4167" />

Console Output:
Total sprinkle points: 9
---------------------------
Sprinkler Point at X: 90647.64958099597, Y: 43999.97367595774, Z: 2511.1050148430863
Nearest pipe connection point at X: 91425.69883575261, Y: 45039.58279737643, Z: 3093.619887234953
---------------------------
Sprinkler Point at X: 93147.6520252992, Y: 41499.97682713698, Z: 2509.7756638305736
Nearest pipe connection point at X: 92705.81310141784, Y: 40882.68870371261, Z: 3269.4845944747995
---------------------------
Sprinkler Point at X: 93147.64112885129, Y: 43999.96277950983, Z: 2515.7017714758194
Nearest pipe connection point at X: 92984.39478843194, Y: 43830.53393305496, Z: 3169.4909169885905
---------------------------
Sprinkler Point at X: 93147.63023240337, Y: 46499.948731882665, Z: 2521.6278791210652
Nearest pipe connection point at X: 93325.86028869216, Y: 46729.717367540004, Z: 3000
---------------------------
Sprinkler Point at X: 95647.65446960244, Y: 38999.97997831622, Z: 2508.446312818061
Nearest pipe connection point at X: 95473.34947729354, Y: 38735.964125397135, Z: 3134.77209050159
---------------------------
Sprinkler Point at X: 95647.64357315452, Y: 41499.96593068906, Z: 2514.3724204633068
Nearest pipe connection point at X: 95751.85157261392, Y: 41683.873786653494, Z: 3304.199546759296
---------------------------
Sprinkler Point at X: 95647.6326767066, Y: 43999.951883061905, Z: 2520.2985281085525
Nearest pipe connection point at X: 96097.4357867254, Y: 44579.82403849673, Z: 3000
---------------------------
Sprinkler Point at X: 98147.64601745775, Y: 38999.9690818683, Z: 2513.043069450794
Nearest pipe connection point at X: 98519.30835679588, Y: 39537.213640252034, Z: 3438.9081765300016
---------------------------
Sprinkler Point at X: 98147.63512100984, Y: 41499.955034241146, Z: 2518.96917709604
Nearest pipe connection point at X: 98869.01128475866, Y: 42429.93070945345, Z: 3000
---------------------------



