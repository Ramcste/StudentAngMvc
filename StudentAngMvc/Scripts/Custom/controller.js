app.controller("studentAngContrl", function ($scope, studentServices) {

    $scope.divStudent = false;

    GetAllStudents();

 
    // to get all student records
    function GetAllStudents()
    {
        //debugger;
        var getStudentData = studentServices.getStudents();
        getStudentData.then(function (student) {
            $scope.students = student.data;
        }, function () {
            alert('Error in getting student records');
        });
    }

    $scope.editStudent = function (student)
    {
        var getStudentData = studentServices.getStudent(student.Id);

        getStudentData.then(function (_student) {
            $scope.student = _student.data;
            $scope.Id = student.Id;
            $scope.Name = student.Name;
            $scope.Email = student.Email;
            $scope.Address = student.Address;
            $scope.DOB = student.DOB;
            $scope.Gender = student.Gender;
            $scope.Action = "Update";
            $scope.divStudent = true;
        },function(){
            alert('Error in getting student records');

        });
    }

    $scope.AddUpdateStudent = function () {
        var Student = {
            Name: $scope.Name,
            Email: $scope.Email,
            PhoneNumber: $scope.PhoneNumber,
            Address: $scope.Address,
            DOB: $scope.DOB,
            Gender: $scope.Gender

        };

        //console.log(Student);

        var getStudentAction = $scope.Action;

        if (getStudentAction == "Update") {
            Student.Id = $scope.Id;
            var getStudentData = studentServices.updateStudent(Student);
            getStudentData.then(function (msg) {
                GetAllStudents();
                alert(msg.data);
                $scope.divStudent = false;

            }, function () {
                alert('Error in updating student record');
            });
        }

        else {
            var getStudentData = studentServices.AddStudent(Student);
            getStudentData.then(function (msg) {
                GetAllStudents();
                alert(msg.data);
                $scope.divStudent = false;
            }, function () {

                alert('Error in adding student records');

            });
        }

    }

    $scope.AddStudentDiv = function () {
        clearFileds();
        $scope.Action = "Add";
        $scope.divStudent = true;
    }

    $scope.deleteStudent = function (student) {
        var getStudentData = studentServices.DeleteStudent(student.Id);
        getStudentData.then(function (msg) {
            alert(msg.data);
            GetAllStudents();
        }, function () {
            alert('Error in deleting student record');
        });
    }

    function clearFileds() {
    $scope.Name = "";
    $scope.Email = "";
    $scope.Address = "";
    $scope.Gender = "";
    $scope.DOB = "";
    $scope.PhoneNumber = "";

}

    $scope.Cancel = function () {
    $scope.divStudent = false;
}


    
});

