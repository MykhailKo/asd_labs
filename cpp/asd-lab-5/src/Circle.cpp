#include "Circle.h"
#include <math.h>

using namespace std;

Circle::Circle() {
	_radius = 1;
}
Circle::Circle(float radius){
	_radius = radius;
}

double Circle::getArea(){
	return M_PI * pow(_radius, 2);
}

double Circle::getPerimeter(){
	return 2 * M_PI * _radius;
}


