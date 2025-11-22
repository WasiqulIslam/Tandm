# Tandm
Tandm Programming Challenge

Your mission, should you choose to accept it, is to calculate the number of sprinklers required to fill a room, their positions on the room’s ceiling and then connect each sprinkler to the nearest water pipe.

The room has a rectangular shape. Ceiling coordinates (x, y, z) are:

(97500.01, 34000.00, 2500.00)

(85647.67, 43193.61, 2500.00)

(91776.75, 51095.16, 2530.00)

(103629.07, 41901.55, 2530.00)

Three water pipes are available:

(98242.11, 36588.29, 3000.00) to (87970.10, 44556.09, 3500.00)

(99774.38, 38563.68, 3500.00) to (89502.37, 46531.47, 3000.00)

(101306.65, 40539.07, 3000.00) to (91034.63, 48507.01, 3000.00)


Sprinklers are to be placed on the ceiling 2500mm away from the walls and from each other. Please, calculate the number of sprinklers that can be fitted into this room, then calculate coordinates (x, y, z) of each sprinkler.

For each sprinkler calculate coordinates (x, y, z) of the connection point to the nearest water pipe.

Implement your solution using C# programming language and .Net Core framework.

Solution plotted in 3D:
---------------------------
<img width="1000" height="800" alt="final" src="https://github.com/user-attachments/assets/603d4e31-f5ea-498c-a42e-7ca0730c93b5" />


Console Output:

Total sprinkle points: 15
---------------------------
Sprinkler Point at X: 89155.31345580675, Y: 43636.71172030407, Z: 2507.4999282238928
Nearest pipe connection point at X: 89183.69587130517, Y: 43614.72709406579, Z: 3440.927049754373
---------------------------
Sprinkler Point at X: 90687.56879177692, Y: 45612.08031553838, Z: 2514.999856447786
Nearest pipe connection point at X: 90671.12705687068, Y: 45624.8888352461, Z: 3056.8903776802536
---------------------------
Sprinkler Point at X: 92219.8241277471, Y: 47587.44891077269, Z: 2522.4997846716788
Nearest pipe connection point at X: 92219.92757751822, Y: 47587.58227499455, Z: 3000
---------------------------
Sprinkler Point at X: 91130.70157564334, Y: 42104.44484537382, Z: 2507.4999282238928
Nearest pipe connection point at X: 91156.16440377072, Y: 42084.7213042565, Z: 3344.915240358474
---------------------------
Sprinkler Point at X: 92662.95691161351, Y: 44079.81344060813, Z: 2514.999856447786
Nearest pipe connection point at X: 92643.5965165446, Y: 44094.88424645626, Z: 3152.902232208915
---------------------------
Sprinkler Point at X: 94195.21224758368, Y: 46055.182035842445, Z: 2522.4997846716788
Nearest pipe connection point at X: 94195.30164612332, Y: 46055.29728565445, Z: 3000
---------------------------
Sprinkler Point at X: 93106.08969547992, Y: 40572.177970443576, Z: 2507.4999282238928
Nearest pipe connection point at X: 93128.63293623626, Y: 40554.7155144472, Z: 3248.9034309625745
---------------------------
Sprinkler Point at X: 94638.3450314501, Y: 42547.54656567788, Z: 2514.999856447786
Nearest pipe connection point at X: 94616.0659762185, Y: 42564.87965766642, Z: 3248.914086737576
---------------------------
Sprinkler Point at X: 96170.60036742027, Y: 44522.9151609122, Z: 2522.4997846716788
Nearest pipe connection point at X: 96170.67571472841, Y: 44523.01229631435, Z: 3000
---------------------------
Sprinkler Point at X: 95081.47781531651, Y: 39039.91109551333, Z: 2507.4999282238928
Nearest pipe connection point at X: 95101.1014687018, Y: 39024.709724637905, Z: 3152.891621566675
---------------------------
Sprinkler Point at X: 96613.73315128668, Y: 41015.27969074764, Z: 2514.999856447786
Nearest pipe connection point at X: 96588.5354358924, Y: 41034.87506887658, Z: 3344.925941266237
---------------------------
Sprinkler Point at X: 98145.98848725685, Y: 42990.64828598195, Z: 2522.4997846716788
Nearest pipe connection point at X: 98146.04978333351, Y: 42990.727306974244, Z: 3000
---------------------------
Sprinkler Point at X: 97056.8659351531, Y: 37507.64422058308, Z: 2507.4999282238928
Nearest pipe connection point at X: 97073.57000116735, Y: 37494.70393482861, Z: 3056.879812170776
---------------------------
Sprinkler Point at X: 98589.12127112327, Y: 39483.01281581739, Z: 2514.999856447786
Nearest pipe connection point at X: 98561.00489556631, Y: 39504.87048008674, Z: 3440.937795794898
---------------------------
Sprinkler Point at X: 100121.37660709344, Y: 41458.381411051705, Z: 2522.4997846716788
Nearest pipe connection point at X: 100121.4238519386, Y: 41458.442317634144, Z: 3000
---------------------------



