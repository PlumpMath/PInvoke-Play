#!/bin/sh

mkdir out
mkdir out/obj

echo Compiling native.cpp
gcc -c -fPIC LibNative/native.cpp -o out/obj/native.o
echo Compiling SizedDoubleArray.cpp
gcc -c -fPIC LibNative/SizedDoubleArray.cpp -o out/obj/SizedDoubleArray.o

echo Linking libnative.so
gcc -shared out/obj/*.o -o out/libnative.so -lstdc++

echo Building Managed.exe
gmcs Managed/Managed.cs \
     Managed/NativeWrapper.cs \
     -out:out/Managed.exe

echo \#!/bin/sh > out/runme.sh
echo mono Managed.exe >> out/runme.sh
chmod +x out/runme.sh

echo out/runme.sh generated. Use it to run tests.
