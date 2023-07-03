package com.company;

public class Main {
	
	private static void t1(){
		while (i < 10){
	        System.out.print(i + " ");
	        i++;
        }
	}
	
	private static String t3(int number) {
        String res = number + " = ";
        int del = number;
        while (del != 1) {
			// Проверяем, что число делится на делитель
            if (number % del != 0) {
                del--;
                continue;
            }
			//Проверяем делитель del на простоту
            int j = del / 2;
            while (j != 1) {
                if (del % j == 0) {
                    del--;
                    break;
                }
                j--;
            }
			//Если мы сюда дошли, то накапливаем результат
            if (j == 1) {
                res += del + " * ";
                number = number / del;
            }
        }
		//Добавляем единичку
        return res + "1";
    }
    
    public static void main(String[] args) {
	    System.out.println("Hello world!");
	    int i = 0;
	    t1();	    
    }
}
