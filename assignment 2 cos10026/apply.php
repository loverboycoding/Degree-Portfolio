<!DOCTYPE html>
<html lang="en">

<?php $title = "Job Application";
include('head.inc'); ?>

<body>

  <?php include('header.inc'); ?>

  <div class="apply">
    
  
    <div>
		<h1>Welcome to LABBOYS, a leading IT company dedicated to innovation and excellence.<br> We're thrilled that you're interested in joining our team!</h1> 
		</div>
    <p>
      Please fill out the form below to apply for the post!!!
    </p>
	<h2>Application Form</h2>

    <form method="post" action="processEOI.php">
      <fieldset class="hideborder">
        <fieldset class="hideborder">
          <label for="Ref_no">Job Reference Number</label>
         
          <input type="text" name="Ref_no" id="Ref_no" required="required"
            pattern="[0-9a-zA-Z]{5}" />
        </fieldset>

        <p>
	<fieldset >
		
		<legend>Personal Information</legend>
		<p>
		<label for="First_name">First name</label>
		<input type="text" name="First_name" id="First_name"  pattern="[A-Za-z]{1;20}" required="required">
		<label for="Last_name">Last name</label>
		<input type="text" name="Last_name" id="Last_name"  pattern="[A-Za-z]{1;20}" required="required">
		</p>
<br>
	<label for="DOB">Date of birth</label>
	<input type="text" name= "DOB" id="DOB" placeholder="dd/mm/yyyy" pattern="\d{1,2}\/\d{1,2}\/\d{4}\" required="required">


	</fieldset>
	
	
		<fieldset class="gender">
			<legend>Gender</legend>
			<input type="radio" name="Gender" id="Male" value="Male" required="required">
			<label for="Male">Male</label>
			<input type="radio" name="Gender" id="Female" value="Female" required="required">
			<label for="Female">Female</label>
			<input type="radio" name="Gender" id="Others" value="Others" required="required">
			<label for="Others" >Others</label>

		</fieldset>
	
<P>
	<fieldset class="address">
		<legend>Address</legend>
		<p><label for="Street_Add">Street Address</label>
		<input type="text" name="Street_Add" id="Street_Add" pattern="[A-Za-z]{1;40}" required="required">
		</p>
		<p>
			<label for="suburb_town">suburb/town</label>
			<input type="text" name="suburb_town" id="suburb_town" pattern="[A-Za-z]{1;40}" required="required">

		</p>
		<p>
			<label for="State">State </label>
			<select name="State" id="State" >
				
				<option value="VIC" >VIC</option>
				<option value="NSW" >NSW</option>
				<option value="QLD">QLD</option>
				<option value="NT">NT</option>
				<option value="WA">WA</option>
				<option value="SA">SA</option>
				<option value="TAS">TAS</option>
				<option value="ACT">ACT</option>
				</select>
		</p>
		
			<label for="Postcode">Postcode</label>
<input type="text"  name="Postcode" id="Postcode" pattern="[0-9]{4}" required="required">
		
	</fieldset>
<p>
	<fieldset class="contact">
		<legend>Contact info</legend>
		<label for="email">Email Address</label>
          <input id="email" type="email" name="email" required="required"
            pattern="^[\w]{1,}[\w.+-]{0,}@[\w-]{2,}([.][a-zA-Z]{2,}|[.][\w-]{2,}[.][a-zA-Z]{2,})$" />
		
		<p>
		<label for="Phone_num">Phone Number</label>
		<input type="text" name="Phone_num" id="Phone_num" pattern="[0-9 ]{8,12}" required="required">
</p>
	</fieldset>


<fieldset class="Skill-list">
	<legend>Skill list</legend>
	
	<br>
	<br>
<p>
	<input type="checkbox" id="html" name="Skills[]" value="html" checked="checked">
        <label for="html">HTML</label><br>

        <input type="checkbox" id="css" name="Skills[]" value="css">
        <label for="css">CSS</label><br>

        <input type="checkbox" id="javascript" name="Skills[]" value="javascript">
        <label for="javascript">JavaScript</label><br>

        <input type="checkbox" id="python" name="Skills[]" value="phyton">
        <label for="python">Python</label><br>

       

        <input type="checkbox" id="c" name="Skills[]" value="c">
        <label for="c">C</label><br>

        <input type="checkbox" id="c++" name="Skills[]" value="c++">
        <label for="c++">C++</label><br>

        <input type="checkbox" id="sql" name="Skills[]" value="sql">
        <label for="sql">SQL</label><br>

        <input type="checkbox" id="php" name="Skills[]" value="php">
        <label for="php">PHP</label><br>

        <input type="checkbox" id="ruby" name="Skills[]" value="ruby">
        <label for="ruby">Ruby</label><br>
	
        <label for="Other_skills">Other skills</label>
		<textarea name="Skills[]" id="Other_skills" ></textarea>
		<br>

</p>
</fieldset>
	<p>
	<input type="submit" value="Submit">
	<input type="reset" value="Reset">
    </p>
	</form>
	<br>
	</body>
  <?php include('footer.inc'); ?>



</html>