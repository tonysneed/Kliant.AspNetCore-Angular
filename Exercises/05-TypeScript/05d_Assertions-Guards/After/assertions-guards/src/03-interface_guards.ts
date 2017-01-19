namespace interface_guards {

    interface CanLearn {
        learn(): void;
    }

    interface CanTeach {
        teach(): void;
    }

    class Person {
        name: string;
        age: number;
    }

    class Student extends Person implements CanLearn {
        learn() {
            console.log("Student learning ...");
        }
    }

    class Teacher extends Person implements CanTeach {
        teach() {
            console.log("Teacher teaching ...");
        }
    }

    class Robot implements CanLearn {
        learn() {
            console.log("Robot learning ...");
        }
    }

    // Update the parameter to a union type
    // function learnOrTeach(being: CanLearn | CanTeach) {
    //     if (being instanceof CanTeach) {
    //         being.teach();
    //     }
    //     if (being instanceof CanLearn) {
    //         being.learn();
    //     }
    // }

    // User-defined type guards
    function canLearn(being: CanLearn | CanTeach): being is CanLearn {
        return (being as CanLearn).learn !== undefined;
    }

    function canTeach(being: CanLearn | CanTeach): being is CanTeach {
        return (being as CanTeach).teach !== undefined;
    }

    function learnOrTeach(being: CanLearn | CanTeach) {
        if (canTeach(being)) {
            being.teach();
        }
        if (canLearn(being)) {
            being.learn();
        }
    }

    let student = new Student();
    let teacher = new Teacher();
    let robot = new Robot();
    learnOrTeach(student);
    learnOrTeach(teacher);
    learnOrTeach(robot);
}