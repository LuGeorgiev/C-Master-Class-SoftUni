#include "pch.h"
#include "iostream"
#include <stdio.h>
extern "C" {
	__declspec(dllexport) int add(int a, int b) 
	{
		std::cout << "C++ is great! ";

		return a + b;
	}

	__declspec(dllexport) int mult(int a, int b) 
	{
		std::cout << "I like C# more! ";

		return a * b;
	}
}