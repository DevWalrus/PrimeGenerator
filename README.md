# PrimeGenerator
Generates a set of (probably) prime numbers as confirmed by the Miller-Rabin algorithm.
These numbers are generated using the C# thread pooling structures using the Parallel.For
methods. Each thread generates a number, checks if it is prime, and dies. If it is prime
it signals to the other threads in the pool to quit and returns the number.

## Usage
```
dotnet run <bits> <count=1>
```
Where bits is the size of the prime number in bits (this must be a multiple of 8 and 
be greater than 32) and count is the number of primes to generate (this defaults to 1
if nothing is provided).

