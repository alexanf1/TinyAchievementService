USE tinyachievements;

SET AUTOCOMMIT=0;
INSERT INTO Achievement VALUES (1,'Look for the Light','Find all Firefly Pendants', '{"firefly_pendants": "30"}'),
(2,'Endure and Survive','Collect all Comics', '{"comics": "14"}'),
(3,'It Was All Just Lying There','Find All Artifacts', '{"artifacts": "14"}'),
(4,'I Got This','Find all Training Manuals', '{"training_manuals": "12"}'),
(5,'Scavenger','Found all collectibles', '{"firefly_pendants": "30"}, "comics": "14", "artifacts": "14", "training_manuals": "12"');
COMMIT;
