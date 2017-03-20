# Exam
Данная программа содержит реализованный алгоритм создания, заполнения и проведения боя двух армий: 
армии состоят из воинов, кавалерии, лучников, конных лучников, лекаря и лечащей башни, а также есть атакующая башня.
Правила:
1. Каждый юнит имеет определенную силу, здоровье и инициативу (значение каждого параметра определяем в конструкторе класса).
2. Заполнение армий происходит рандомно.
3. На каждом шагу выбранный юнит наносит урон здоровью противника (рандомно выбранного) на уровень своей силы ЛИБО лечит здоровье произвольных юнитов из своей армии (Лекарь – не более 1 юнита не более чем на 2
единицы здоровья; Лечащая башня – не более 3х юнитов, не более чем на 15 единиц здоровья за 1 ход).
4. Результаты каждого хода записываются в файл (bin->Debug->ArmyFile). На консоль выводится только итог боя.
5. Алгоритм боя (цикл: пока 1 или 2 армия не пуста): 
 - первым удар наносит рандомный юнит с максимальной инициативой (1 - max, 6 - min) - противник из противоположной армии выбирается рандомно;
 - следующий удар за юнитом, с инициативой меньшей предыдущего на 1: т.е. инициатива = 2, затем 3, 4, 5 и 6;
 - далее цикл с инициативой повторяется
 
 
 Дополнительная информация:
1. У каждого юнита есть уровень здоровья:
- Воин – 5
- Кавалерия – 10
- Лучник – 3
- Конный лучник – 7
- Лекарь – 3
- Лечащая башня – 20
- Атакующая башня – 30
2. Некоторые юниты могут атаковать с
определенной силой:
- Воин – 2
- Кавалерия – 7
- Лучник – 3
- Конный лучник – 10
- Атакующая башня – 20
3. Юниты обладают инициативой, которая
определяет порядок ходов:
- Башни имеют инициативу 1
- Конный лучник – 2
- Кавалерия – 3
- Лучник – 4
- Лекарь – 5
- Воин – 6
