<?php
include 'settings.php';

// Function to sanitize input data
function sanitize_input($data) {
    $data = trim($data);
    $data = stripslashes($data);
    $data = htmlspecialchars($data);
    return $data;
}

//validation  Function 
function validate_data($data) {
    $errors = [];

    // Validate job reference num exactly 5  alphanumeric characters
    if (!preg_match("/^[0-9a-zA-Z]{5}$/", $data['Ref_no'])) 
       { $errors[] = "Job reference number must be exactly 5  alphanumeric digit."; }

    // Validate names 
    if (!preg_match("/^[A-Za-z]{1,20}$/", $data['First_name']))
     {$errors[] = "Your First name must be maximum 20 alphabetic characters.";}
    if (!preg_match("/^[A-Za-z]{1,20}$/", $data['Last_name'])) {
        $errors[] = "Your Last name must be maximum 20 alphabetic characters.";
    }

    // Validate date of birth 15 to 80
    $dob = DateTime::createFromFormat('d/m/Y', $data['DOB']);
    $age = $dob ? $dob->diff(new DateTime())->y : 0;
    if (!$dob || $age < 15 || $age > 80) {
        $errors[] = "Date of birth must be in dd/mm/yyyy format and your age should be between 15 and 80.";
    }

    // Validate gender 
    if (empty($data['Gender'])) {
        $errors[] = "Gender must be selected.";
    }

    // Validate address 
    if (strlen($data['Street_Add']) > 40) {
        $errors[] = "Street address must be a maximum of 40 characters.";
    }
    if (isset($data['suburb_town']) && strlen($data['suburb_town']) > 40) {
        $errors[] = "suburb_town must be a maximum of 40 characters.";
    }
    if (!in_array($data['State'], ['VIC', 'NSW', 'QLD', 'NT', 'WA', 'SA', 'TAS', 'ACT'])) {
        
    }
    if (!preg_match("/^[0-9]{4}$/", $data['Postcode'])) {
        $errors[] = "Postcode must be exactly 4 digits.";
    }

    // Validate email address
    if (!filter_var($data['email'], FILTER_VALIDATE_EMAIL)) {
        $errors[] = "Invalid email address !!!";
    }

    // Validate phone num (8 to 12 digits, or spaces)
    if (!preg_match("/^[0-9 ]{8,12}$/", $data['Phone_num'])) {
        $errors[] = "Phone number must be 8 to 12 digits or spaces.";
    }

    return $errors;
}

// Process form data
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Sanitize the input data
    $Ref_no = sanitize_input($_POST['Ref_no']);
    $First_name = sanitize_input($_POST['First_name']);
    $Last_name = sanitize_input($_POST['Last_name']);
    $DOB = sanitize_input($_POST['DOB']);
    $Gender = sanitize_input($_POST['Gender']);
    $Street_Add = sanitize_input($_POST['Street_Add']);
    $suburb_town = isset($_POST['suburb_town']) ? sanitize_input($_POST['suburb_town']) : null;
    $State = sanitize_input($_POST['State']);
    $Postcode = sanitize_input($_POST['Postcode']);
    $email = sanitize_input($_POST['email']);
    $Phone_num = sanitize_input($_POST['Phone_num']);
    $Skills = implode(', ', array_map('sanitize_input', $_POST['Skills']));

    $data = [
     'Ref_no' => $Ref_no,
    'First_name' => $First_name,
    'Last_name' => $Last_name,
     'DOB' => $DOB,
     'Gender' => $Gender,
     'Street_Add' => $Street_Add,
    'suburb_town' => $suburb_town,
     'State' => $State,
     'Postcode' => $Postcode,
     'email' => $email,
     'Phone_num' => $Phone_num,
     'Skills' => $Skills,
    ];

    // Validate data
    $errors = validate_data($data);

    if (empty($errors)) {
        // Prepare and bind
        $stmt = $conn->prepare("INSERT INTO eoi (Ref_no, First_name, Last_name, DOB, Gender, Street_Add, suburb_town, State, Postcode, email, Phone_num, Skills) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");

        if ($stmt) {
            $stmt->bind_param("ssssssssssss", $Ref_no, $First_name, $Last_name, $DOB, $Gender, $Street_Add, $suburb_town, $State, $Postcode, $email, $Phone_num, $Skills);

            // Execute statement
            if ($stmt->execute()) {
                $last_id = $stmt->insert_id;
                echo "New record created successfully. Your EOI number is: " . $last_id;
            } else {
                echo "Error: " . $stmt->error;
            }

            $stmt->close();
        } else {
            // Handle prepare() failure
            echo "Prepare statement failed: (" . $conn->errno . ") " . $conn->error;
        }

        $conn->close();
    } else {
        // Display errors
        foreach ($errors as $error) {
            echo "<p>Error: $error</p>";
        }
    }
} else {
    
    header("Location: apply.php");
    exit();
}
?>
