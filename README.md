# TSPSolver
C# Christofides' Algorithm for the Travelling Salesman Problem

5 Samples are given as examples.
These can be switched easily by changing sample.sample1 to sample.sample2.

Data input: List<Coord>, where Coord stores index, name, and x/y coordinates.
Output: The indexes of the points, sorted in a way that approximates the TSP problem.

Algorithm:
Christofides Algorithm was implemented with some several tweaks.
Algorithm:
1. Solve the minimum spanning tree with Prim's algorithm
2. Connect the tree into an Eulerian path, using depth first search
3. Create a hamiltonian path by deleting repeated verticies
4. Improve the path using the 3-opt algorithm

Several improvements can be made to this algorithm:
- In step 2, create a minimum weight perfect matching subgraph with all the odd vertices to make a shorter Eulerian path.
- In step 4, repeat the 3-opt algorithm until the solution reaches its local minimum. (not guarenteed to be optimal though)

Overall algorithm complexity is O(n^3), which is relatively fast at small graphs with under 500 nodes, but becomes significantly slower with more nodes.
This can be reduced to O(n^2 log(n)) by replacing 3-opt to 2-opt, but is still relatively slow.
