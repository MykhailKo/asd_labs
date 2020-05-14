#ifndef MYCALC_H_
#define MYCALC_H_
#include "math.h"
#include <iostream>
using namespace std;

class MyCalc {
public:
	MyCalc(double, double, double);
	virtual ~MyCalc();
	void setArgA(double);
	void setArgC(double);
	void setArgD(double);
	double getArgA();
	double getArgC();
	double getArgD();
	double calculate();
private:
	double _a, _c, _d;
};

#endif
