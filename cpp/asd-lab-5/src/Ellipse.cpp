#include "Ellipse.h"
#include "math.h"
using namespace std;


Ellipse::Ellipse() {
	_semiHeight = 1;
	_semiWidth = 1;
}
Ellipse::Ellipse(float semiHeight, float semiWidth){
	_semiHeight = semiHeight;
	_semiWidth = semiWidth;
}
double Ellipse::getArea(){
	return M_PI * _semiHeight * _semiWidth;
}

double Ellipse::getPerimeter(){
	return 2 * M_PI * sqrt((pow(_semiHeight, 2) + pow(_semiWidth, 2))/2);
}


