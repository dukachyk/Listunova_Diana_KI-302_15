package ki302.Listunova.Lab6;

import java.util.*;
import java.io.*;

public class Minecart {
    public static void main(String[] args) {
        Wagon<? super Cargo> wagon = new Wagon<>();

        wagon.addCargo(new Passenger("Astarion", 75));
        wagon.addCargo(new Passenger("Gale", 75));
        wagon.addCargo(new Freight("Coal", 3000));
        wagon.addCargo(new Freight("Steel", 5000));

        Cargo maxCargo = wagon.findMax();
        System.out.print("The largest cargo in the wagon is: \n");
        maxCargo.print();
    }
}

class Wagon<T extends Cargo> {
    private ArrayList<T> cargoList;

    public Wagon() {
        cargoList = new ArrayList<>();
    }

    public T findMax() {
        if (!cargoList.isEmpty()) {
            T max = cargoList.get(0);
            for (int i = 1; i < cargoList.size(); i++) {
                if (cargoList.get(i).compareTo(max) > 0) {
                    max = cargoList.get(i);
                }
            }
            return max;
        }
        return null;
    }

    public void addCargo(T cargo) {
        cargoList.add(cargo);
        System.out.print("Cargo added: ");
        cargo.print();
    }

    public void removeCargo(int index) {
        if (index >= 0 && index < cargoList.size()) {
            cargoList.remove(index);
        }
    }
}

interface Cargo extends Comparable<Cargo> {
    public int getWeight();
    public void print();
}

class Passenger implements Cargo {
    private String name;
    private int weight;

    public Passenger(String name, int weight) {
        this.name = name;
        this.weight = weight;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public int compareTo(Cargo other) {
        return Integer.compare(this.weight, other.getWeight());
    }

    public void print() {
        System.out.print("Passenger: " + name + ", Weight: " + weight + " kg;\n");
    }
}

class Freight implements Cargo {
    private String type;
    private int weight;

    public Freight(String type, int weight) {
        this.type = type;
        this.weight = weight;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public int compareTo(Cargo other) {
        return Integer.compare(this.weight, other.getWeight());
    }

    public void print() {
        System.out.print("Freight: " + type + ", Weight: " + weight + " kg;\n");
    }
}

