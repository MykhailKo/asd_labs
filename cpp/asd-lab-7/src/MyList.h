
#ifndef MYLIST_H_
#define MYLIST_H_

#include "Node.h"

class MyList {
public:
	int Count();
	double Sum();
	void Add(double data);
	void RemoveEven();
	int FindNumOfMoreThanAverage();
	void ShowList();
private:
	int _count;
	double _sum;
	Node *_head;
	Node *_tail;
};

#endif
