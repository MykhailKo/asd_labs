#ifndef CIRCLE_H_
#define CIRCLE_H_

#include "Figure.h"

class Circle: public Figure {
public:
	Circle();
	Circle(float radius);
	double getArea();
	double getPerimeter();
private:
	float _radius;
};


#endif
