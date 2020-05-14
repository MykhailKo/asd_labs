#include "MyCalc.h"

MyCalc::MyCalc(double a, double c, double d) {
	if(a + c == 1) throw 1;
	if(d == 0) throw 2;
	if(d < 0) throw 1.0;
	_a = a;
	_c = c;
	_d = d;
}

MyCalc::~MyCalc() {
	_a = 0;
	_c = 0;
	_d = 0;
	delete &_a;
	delete &_c;
	delete &_d;
}

void MyCalc::setArgA(double a){
	if(a + _c == 1) throw 1;
	_a = a;
}

void MyCalc::setArgC(double c){
	if(_a + c == 1) throw 1;
	_c = c;
}

void MyCalc::setArgD(double d){
	if(d == 0) throw 2;
	if(d < 0) throw 1.0;
	_d = d;
}

double MyCalc::calculate(){
	return (2 * _a - _d * sqrt(42 / _d)) / (_a + _c - 1);
}

double MyCalc::getArgA(){
	return _a;
}

double MyCalc::getArgC(){
	return _c;
}

double MyCalc::getArgD(){
	return _d;
}
