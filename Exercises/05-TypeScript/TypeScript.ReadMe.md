# Exercise: TypeScript Basics

## Prerequisites

1. Install TypeScript with NPM

## Part A: TypeScript Type System

1. Open a command prompt and navigate to the type-system folder in the Before directory 
   and navigate to the project directory.
    - Install NPM packages listed in packages.json.

    ```
    npm install
    ```

    *Note: Unless otherwise noted, you will need to run npm install from a 
    command line at the project root prior to beginning work on each part of the lab.*

2. Open Visual Studio Code at the project root, and add a file 
   to the src directory named 01-dynamic-typing.ts.
    - Begin by adding a dynamic_typing namespace to the file. 
      Be sure to place code that follows in this namespace.

    ```js
    namespace dynamic_typing {
    }
    ```

    *Note: Namespaces are required in order to avoid collisions between variables 
     with the same name that have been declared in the global namespace.*

3. Add a Person class with two properties: name (string) and age (number).

    ```js
    class Person {
        name: string;
        age: number;
    }
    ```

4. Add a Student class with an enrolled property (Date).

    ```js
    class Student {
        enrolled: Date;
    }
    ```

5. Then add a birthday function in the namespace that accepts a person parameter of type any and increments the age by 1.

    ```js
    function birthday(person: any) {
        person.age += 1;
    }
    ```

6. Create a new Student and assign it to a variable named joe. Set his age to 18.

    ```js
    let joe: any = new Student();
    joe.age = 18;
    ```

7. Lastly, call the birthday function, passing joe as the parameter. Then write his age to the console.

    ```js
    birthday(joe);
    console.log(joe.age);
    ```

    - Compile the project by pressing CMD + SHIFT + B (Mac) or CTRL + SHIFT + B (Windows / Linux). 
      There should not be any compilation errors.
    - Show the Debug Console by pressing CMD + SHIFT + Y (Mac) or CTRL + SHIFT + Y (Windows / Linux), 
      and press F5 to launch the debugger and run the code.
    - You should see the number 19 printed to the console.
    - Press SHIFT + F5 to stop the debugger.
    - The reason the code compiles and runs is that it leverages 
      JavaScript’s native support for dynamic typing. 

8. Copy and rename 01-dynamic-typing.ts to 02-structural-typing.ts, and rename the namespace to structural_typing.
    - Refactor the code to replace any with Person.
    - Do this in both in the birthday function and the initialization of the joe variable.

    ```js
    function birthday(person: Person) { // Remaining code elided ...
    let joe: Person = new Student();
    ```

    - You will now see a compilation error appear on the line of code on which joe is initialized, 
     complaining that Student is missing a name property, which is how the TypeScript compiler enforces type safety.
    - Go ahead and copy the name property from Person to Student. The compilation error will remain 
      but state that the age property is missing from Student. Copy the age property from Person to Student, 
      and the compilation error will go away.

    ```js
    class Student {
        name: string;
        age: number;
        enrolled: Date;
    }
    ```

    - Notice that TypeScript allows conversion from Student to Person even though Student does not 
      explicitly extend Person. This is because TypeScript uses structural typing to determine 
      that the two types are compatible – Student has all the properties of Person, so it must be a Person. 
      This is commonly referred to as duck typing: “If it quacks and walks like a duck, it must be a duck!”
    - Compile and run the program. You should see the number 19 printed to the Debug Console.

    *Note: You may need to clear output from the Debug Console in order verify that the program ran correctly.*

9. Copy and rename 02-structural-typing.ts to 03-nominal-typing.ts, and rename the namespace to nominal_typing.
    - Go ahead and remove the type annotation from the joe variable, so that it is assumed to be of type Student.
    - Add a protected property named gender of type string to the Person class.

    ```js
    protected gender: string;
    ```

    - You should notice a compilation on the line at which the birthday function is called, stating that Student is not assignable to Person because it is missing the gender property.
    - Rather than adding the gender property to Student, you can take advantage of nominal typing in TypeScript by refactoring Student to explicitly extend the Person type. Change the definition of Student as follows:

    ```js
    class Student extends Person {
    ```

    - Notice that the code compiles, even though Student has the same name and age properties as Person. 
      But seeing as one of the benefits of nominal typing is code reuse, you can safely remove name 
      and age properties from Student without causing any compilation errors. Person and Student should appear as follows:

    ```js
    class Person {
        protected gender: string;
        name: string;
        age: number;
    }

    class Student extends Person {
        enrolled: Date;
    }
    ```

10. After the line of code that creates a Student, set the name and enrolled properties as follows:

    ```js
    joe.name = "Joe";
    joe.enrolled = new Date();
    ```

    - Update console.log to display these properties as well.

    ```
    console.log(`Student named ${joe.name}, age ${joe.age}, enrolled on: ${joe.enrolled.toDateString()}`);
    ```

    - Output similar to the following should be displayed in the Debug Console:

    ```
    Student named Joe, age 19, enrolled on: Fri Sep 02 2016
    ```

## Part B: Type Inference

1. Open Visual Studio Code in the type-inference folder at the Before directory.
    - In the src directory, you will find a file named 01-type-inference.ts. 
      Open the file and have a look at the contents.
    - You will see four classes: Person, Student, Faculty, and Mascot. 
      Student and Faculty extend Person, which has a talk method.

    ```js
    class Person {
        talk() {
            console.log("Hello");
        }
    }

    class Student extends Person {
    }

    class Faculty extends Person {
    }

    class Mascot {
    }
    ```

    - You will also see three lines of code that initialize new instances of Student, Faculty, and Mascot.

    ```js
    let student = new Student();
    let teacher = new Faculty();
    let mascot = new Mascot();
    ```

2. Create a variable called people and initialize it to an array that includes a student and teacher.

    ```js
    let people = [student, teacher];
    ```

    - Invoke the talk function on the first element of the array.

    ```js
    people[0].talk();
    ```

    - You’ll notice that TypeScript infers the people variable to be an array of Person. 
      This is indicated by intellisense when you mouse over the call to the talk function.

    - While you’re at it, call talk on the second element of the array.

    ```js
    people[1].talk();
    ```

    - Compile and run the program to make sure it works as expected, 
      which is to print Hello to the console two times.

3. Next add a variable called mammals and initialize it to an array with student, teacher, and mascot.

    ```js
    let mammals = [student, teacher, mascot];
    ```

    - Call talk on the first element of the array.

    ```js
    mammals[0].talk();
    ```

    - This time you will receive a compilation error stating: “Property 'talk' does not exist on type 'Mascot'.” 
      This indicates that TypeScript selected Mascot as the best common type, based on structural typing.

    - Add a type property (string) to Mascot.

    ```js
    class Mascot {
        type: string;
    }
    ```

    - The compilation error will now indicate that TypeScript is inferring a type that combines Student and Mascot.
4. Lastly, add a talk method to Mascot, logging “Woof” to the console.
    - The compile error will now disappear, because TypeScript is inferring 
      Person as the best common type, based on structural typing.

    - While you’re at it, go ahead and call talk on the second and third elements of the mammals array. 
      Then compile and run the program to observe the output.

## Part C: typeof Operator and Union Types

1. Open Visual Studio Code in the typeof-union folder at the Before directory.
    - In the src directory, you will find a file named 01-enrolled_date.ts. 
      Open the file and have a look at the contents. There you will see Person and Student classes. 
    - Student extends Person and has a private enrolled property with methods to set and get the enrollment date.

    ```js
    class Student extends Person {
        private enrolled: Date;
        setEnrolled(date: Date) {
            this.enrolled = date;
        }
        getEnrolled(): string {
            return this.enrolled.toDateString();
        }
    }
    ```

    - There is also code that initializes a new Student, sets the enrollment date, 
      and displays student information to the console.

    ```js
    let student = new Student();
    student.name = "Sue";
    student.age = 20;
    student.setEnrolled(new Date());
    ```

    ```
    console.log(`Student named ${student.name}, age ${student.age}, ` +
        `enrolled on: ${student.getEnrolled()}`);
    ```

    - Compile and run the code. You should see student information logged to the console, 
      with today’s date set as the enrollment date.

2. Copy and rename 01-enrolled_date.ts to 02-enrolled_any.ts. 
   Then rename the namespace to enrolled_any.
    - Your task will be to refactor the setEnrolled function to accept either a date or string. 
      The typeof operator will allow you to determine if the date parameter is a string.
    - Start by changing the parameter type on the date parameter for the setEnrolled function from Date to any. 
      Then in the body of setEnrolled, use the typeof parameter to see if the date parameter is a string and, 
      if so, pass it to the constructor of Date to create a new date that has been parsed from the string.

    ```js
    // Change parameter to any
    setEnrolled(date: any) {

        // See if a string was passed in
        if (typeof date === "string") {

            // Set enrolled to a new Date based on string value
            this.enrolled = new Date(date);
        }
        else {
            this.enrolled = date;
        }
    }
    ```

    - To call setEnrolled, you’ll need to create a string representation of today’s date, 
      which depends on how dates are represented in your region. For the United States, 
      dates are formatted as mm/dd/yyyy, as shown below. You may need to modify the code 
      to match your geographic region.

    ```js
    let today = new Date();
    let dateString = `${today.getMonth()}/${today.getDate()}/${today.getFullYear()}`;
    student.setEnrolled(dateString);
    ```

    - Compile and run the code to see the enrollment date displayed along with the other student information.

3. Copy and rename 02-enrolled_any.ts to 03-enrolled_union.ts, and rename the namespace to enrolled_union.

4. Comment out the code that initializes dateString and calls setEnrolled; 
   then call setEnrolled passing a number, such as 12345.

    ```js
    // let dateString = `${today.getMonth()}/${today.getDate()}/${today.getFullYear()}`;
    // student.setEnrolled(dateString);
    student.setEnrolled(12345);
    ```

    - Compile and run the program. The debugger will break on an exception that takes place in the getEnrolled function. 
      The exception message will be: "this.enrolled.toDateString is not a function." 
      The reason is simple. Because you passed a number to setEnrolled, this.enrolled was set to a number, 
      and the number type does not have a toDateString function.

    *Note: Even though the enrolled property on Student is annotated as a Date, 
    TypeScript respects the dynamic nature of JavaScript, which allows enrolled to be set to any type at runtime.*

5. In order to prevent a non-Date value other than string from being passed to setEnrolled, you can use a union type.
    - Change the type annotation on the date parameter to a union of string and Date types.

    ```js
    setEnrolled(date: string | Date) {
    ```

    - You’ll now get a compile error on the line of code that passes a number to setEnrolled: 
      “Argument of type 'number' is not assignable to parameter of type 'string | Date'.”
    - To resolve the error, simply pass the today variable, which is a Date, instead of a number.

6. If you mouse over the date variable on the line in setEnrolled that follows use of the typeof operator, 
   you’ll notice that TypeScript has “narrowed” the union type to a string. Similarly, 
   mousing over the date variable in the else block will indicate that date has been narrowed to a Date. 
   The benefit of type narrowing is that you can treat the variable in each scope as the narrowed type.

## Part D: Type Assertions and Type Guards

1. Open Visual Studio Code in the assertions-guards folder at 
   the Before directory and navigate to the project directory.
    - Open the file 01-person_assertions.ts. There you will find Person, Student, and Teacher classes.
    - Insert a function called learnOrTeach that accepts a person parameter of type Person.
    - Check for the existence of the teach function on person, then invoke teach. 
      Do the same with regard to the learn function.

    ```js
    function learnOrTeach(person: Person) {
        if (person.teach) {
            person.teach();
        }
        if (person.learn) {
            person.learn();
        }
    }
    ```

    - Notice that you get compile errors indicating that teach and learn methods do not 
      exist on the Person type. To eliminate the errors, you can add a type assertion 
      in the form of the as operator.

    ```js
    function learnOrTeach(person: Person) {
        if ((person as Teacher).teach) {
            (person as Teacher).teach();
        }
        if ((person as Student).learn) {
            (person as Student).learn();
        }
    }
    ```

    - Lastly, add code to create a student and teacher and call learnOrTeach, passing each one to the function.

    ```js
    let student = new Student();
    let teacher = new Teacher();
    learnOrTeach(student);
    learnOrTeach(teacher);
    ```

    - Compile and run the code to see expected output.

2. Copy and rename 01-person_assertions.ts to 01-person_instanceof.ts, and rename the namespace to person_instanceof.
    - Use of the as operator in the previous section is a bit cumbersome, 
      because you need to assert the type twice – first to check for the existence of a method, 
      then to execute the method. The typeof operator won’t help much because it will return 
      “object” for both Student and Teacher.
    - Instead of the as operator, you can use the instanceof operator to check whether person 
      is a Student or Teacher type. This has the effect of “narrowing” the type, 
      so there’s no need to use a type assertion when invoking a method on the object.
    - Refactor the learnOrTeach function to replace use of the as operator with instanceof to check for type compatibility.

    ```js
    function learnOrTeach(person: Person) {
        if (person instanceof Teacher) {
            person.teach();
        }
        if (person instanceof Student) {
            person.learn();
        }
    }
    ```

    - Compile and run the program to make sure it works as expected.

3. Copy and rename 02-person_instanceof.ts to 03-interface_guards.ts, and rename the namespace to interface_guards.
    - Let’s say we want to add a Robot class that has a learn function (assuming it has artificial intelligence), 
      but it does not extend the Person class (for obvious reasons).

    ```js
    class Robot {
        learn() {
            console.log("Robot learning ...");
        }
    }
    ```

    - While you’re at it, update the log message for Student and Teacher to include the class name.

    ```
    console.log("Student learning ...");
    console.log("Teacher teaching ...");
    ```

    - To generalize the code, create a pair of interfaces, CanLearn and CanTeach, and insert learn and teach methods.

    ```js
    interface CanLearn {
        learn(): void;
    }

    interface CanTeach {
        teach(): void;
    }
    ```

    *Note: We will learn more about interfaces in a subsequent module.*

    - Update Student and Robot classes to implement CanLearn. Update the Teacher class to implement CanTeach.

    ```js
    class Student extends Person implements CanLearn {
    class Teacher extends Person implements CanTeach {
    class Robot implements CanLearn {
    ```

4. Next, refactor the learnOrTeach function by replacing the person parameter with a parameter 
   called being that is a union of CanLearn and CanTeach. Then in each if block, 
   replace the type name with the interface name.

    ```js
    function learnOrTeach(being: CanLearn | CanTeach) {
        if (being instanceof CanTeach) {
            being.teach();
        }
        if (being instanceof CanLearn) {
            being.learn();
        }
    }
    ```

    - You will receive compilation errors, because instanceof cannot be used with an interface, 
       and also because the union type only contains properties that are in common between the two interfaces.

5. To eliminate the compilation errors, you can create a user-defined type guard, which can perform a runtime 
   check for type compatibility using the as operator.
    - Create a canLearn function with a being parameter of type CanLearn | CanTeach that performs a 
       type assertion using the as operator to determine if the learn method is not undefined.
    - In order for type narrowing to take place, canLearn will need to return a predicate in the form: parameterName is Type.

6. Create another user-defined type guard called canTeach that performs the same kind of type check for the CanTeach interface.

    ```js
    function canLearn(being: CanLearn | CanTeach): being is CanLearn {
        return (being as CanLearn).learn !== undefined;
    }

    function canTeach(being: CanLearn | CanTeach): being is CanTeach {
        return (being as CanTeach).teach !== undefined;
    }
    ```

    - Refactor the learnOrTeach function to replace use of the instanceof operator with user-defined type guards.

    ```js
    function learnOrTeach(being: CanLearn | CanTeach) {
        if (canTeach(being)) {
            being.teach();
        }
        if (canLearn(being)) {
            being.learn();
        }
    }
    ```

7. Lastly, add code to create a new Robot and pass it to learnOrTeach.

    ```js
    let robot = new Robot();
    learnOrTeach(robot);
    ```

    - Compile and run the program to verify expected output is displayed in the console.



