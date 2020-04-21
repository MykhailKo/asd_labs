#ifndef ELLIPSE_H_
#define ELLIPSE_H_

#include "Figure.h"

class Ellipse: public Figure {
public:
	Ellipse();
	Ellipse(float semiHeight, float semiWidth);
	double getArea();
	double getPerimeter();
private:
	float _semiHeight, _semiWidth;
};

#endif
