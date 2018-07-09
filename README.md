# Spatial Keyword Search
R tree with incremental nearest neighbor algorithm to traverse the tree, searching for keywords.

This repo is part of a project investigating how to efficiently search for locations based on the user’s location and preferences in a mobile application. 

The project consists of two different ways of searching for keywords in spatial data: 
- The Linear approach 
- R tree approach

The linear approach is a simple way to solve the problem. It searches through all the restaurant entries to calculate the distance from the user to the restaurants. When all the distances are calculated, the restaurants within the specified range can then be searched for the keywords that the user entered. This is very expensive in terms of efficiency especially for huge amount of data. 

Since efficiency is vital in a real-world application due to the rapidly growth of the data volume, we looked for another approach to improve the query efficiency. The R tree approach was used to accelerate the efficiency. The R tree approach uses an R-tree with an incremental k nearest neighbor algorithm to search for the restaurant entries.

The performance of the two algorithms where evaluated for different values of k and different numbers of keywords. In each experiment, we used the runtime of the algorithms and the number of distance computations to measure the performance of the algorithm. The experiment was conducted on a dataset containing 500000 real-life restaurants, with a variety of different keywords ranging from 2 to 7. The results of the experiments showed the immense performance advantage of using the R tree approach compared to the linear approach.

- The R tree code is from the C# [RBush](https://github.com/viceroypenguin/RBush) library.
