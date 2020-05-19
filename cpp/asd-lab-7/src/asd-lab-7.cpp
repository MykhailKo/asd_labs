#include <iostream>
#include "MyList.h"
using namespace std;

int main() {
	MyList *list = new MyList();
	list->Add(1.1);
	list->Add(1.2);
	list->Add(1.3);
	list->Add(1.4);
	list->Add(1.5);
	list->Add(1.6);
	cout << list->FindNumOfMoreThanAverage() << endl;
	list->RemoveEven();
	list->ShowList();
	return 0;
}
