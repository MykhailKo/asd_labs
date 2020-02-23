################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
../src/Stringy.cpp \
../src/Texty.cpp \
../src/asd-lab-2.cpp 

OBJS += \
./src/Stringy.o \
./src/Texty.o \
./src/asd-lab-2.o 

CPP_DEPS += \
./src/Stringy.d \
./src/Texty.d \
./src/asd-lab-2.d 


# Each subdirectory must supply rules for building sources it contributes
src/%.o: ../src/%.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: Cross G++ Compiler'
	mingw32-g++ -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@)" -o "$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


