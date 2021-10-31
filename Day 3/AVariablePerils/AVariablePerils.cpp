// AVariablePerils.cpp : This file contains the 'main' function. Program execution begins and ends there.
// PLEASE IGNORE THIS DEMO FOR NOW!

#include <iostream>
#include <Windows.h>

int isWorking;

DWORD WINAPI Worker(LPVOID param) 
{
    std::cout << "Thread is starting.";
    Sleep(5000);
    isWorking = 0;
    std::cout << "Thread ended.";
    return 0;
}

int main()
{
    isWorking = 1;
    HANDLE thread =  CreateThread(NULL, 0, Worker, NULL, 0, NULL);
    std::cout << "Main thread waiting:";
    while (isWorking) {
        Sleep(100);
        std::cout << ".";
    }
    std::cout << "\n";
    std::cout << "Waiting completed.";
    std::string s;
    std::cin >> s;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
