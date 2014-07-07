#include "stdafx.h"
#include "ScriptLoader.h"

#include <string>
#include <fstream>
#include <iostream>

using namespace std;

bool ScriptLoader::Load(_TCHAR* fileName)
{
   ifstream fileStream(fileName);

   string line;

   while (getline(fileStream, line))
   {
      
      cout << line << endl;
   }
      
   fileStream.close();

   return true;
}
