--Part 1
Id int : AI PK 
Name :longtext 
Location : longtext
--Part 2
SELECT * FROM employers WHERE Location = "Saint Louis City"

--Part 3
SELECT * FROM skills INNER JOIN jobskills ON skills.Id =
jobskills.SkillId WHERE jobskills.JobId 
IS NOT NULL ORDER BY Name ASC;
