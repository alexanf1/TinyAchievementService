USE tinyachievements;

SET AUTOCOMMIT=0;
INSERT INTO Tinyachievements.Achievement VALUES
('969718df-4c4f-4a1b-95d1-924cc67d1039', 'ACH_FIND_ALL_PENDANTS', 'Look for the Light', 'Find all Firefly Pendants', '{"firefly_pendants": "30"}'),
('2d251bec-770a-4d91-8d05-902575cd46fc', 'ACH_FIND_ALL_COMICS', 'Endure and Survive', 'Collect all Comics', '{"comics": "14"}'),
('af8c9d1d-7777-4c1f-afc8-fbb7c025da25', 'ACH_FIND_ALL_ARTIFACTS', 'It Was All Just Lying There', 'Find All Artifacts', '{"artifacts": "14"}'),
('ee9bbc8e-0d76-498a-bbe7-69c1ea9eb6e0', 'ACH_FIND_ALL_MANUALS', 'I Got This','Find all Training Manuals', '{"training_manuals": "12"}'),
('ec3abf92-5765-425a-8f04-693113795af3', 'ACH_FIND_ALL_COLLECTIONS', 'Scavenger','Found all collectibles', '{"firefly_pendants": "30", "comics": "14", "artifacts": "14", "training_manuals": "12"}');
COMMIT;

SET AUTOCOMMIT=0;
INSERT INTO Tinyachievements.PlayerAchievement VALUES
('aaa2e063-d2d9-4df4-8593-eeb75ef9be37', '969718df-4c4f-4a1b-95d1-924cc67d1039', true),
('aaa2e063-d2d9-4df4-8593-eeb75ef9be37', '2d251bec-770a-4d91-8d05-902575cd46fc', false),
('aaa2e063-d2d9-4df4-8593-eeb75ef9be37', 'af8c9d1d-7777-4c1f-afc8-fbb7c025da25', false),
('aaa2e063-d2d9-4df4-8593-eeb75ef9be37', 'ee9bbc8e-0d76-498a-bbe7-69c1ea9eb6e0', true),
('aaa2e063-d2d9-4df4-8593-eeb75ef9be37', 'ec3abf92-5765-425a-8f04-693113795af3', false),

('d3606189-5b72-43a9-84cd-b6b176bf7868', '969718df-4c4f-4a1b-95d1-924cc67d1039', true),
('d3606189-5b72-43a9-84cd-b6b176bf7868', '2d251bec-770a-4d91-8d05-902575cd46fc', false),
('d3606189-5b72-43a9-84cd-b6b176bf7868', 'af8c9d1d-7777-4c1f-afc8-fbb7c025da25', true),
('d3606189-5b72-43a9-84cd-b6b176bf7868', 'ee9bbc8e-0d76-498a-bbe7-69c1ea9eb6e0', true),
('d3606189-5b72-43a9-84cd-b6b176bf7868', 'ec3abf92-5765-425a-8f04-693113795af3', false),

('eadc241d-3986-47f2-b6c7-bec50eec2243', '969718df-4c4f-4a1b-95d1-924cc67d1039', true),
('eadc241d-3986-47f2-b6c7-bec50eec2243', '2d251bec-770a-4d91-8d05-902575cd46fc', true),
('eadc241d-3986-47f2-b6c7-bec50eec2243', 'af8c9d1d-7777-4c1f-afc8-fbb7c025da25', true),
('eadc241d-3986-47f2-b6c7-bec50eec2243', 'ee9bbc8e-0d76-498a-bbe7-69c1ea9eb6e0', true),
('eadc241d-3986-47f2-b6c7-bec50eec2243', 'ec3abf92-5765-425a-8f04-693113795af3', true);
COMMIT;

SET AUTOCOMMIT=0;
INSERT INTO Tinyachievements.Player VALUES
('aaa2e063-d2d9-4df4-8593-eeb75ef9be37'),
('d3606189-5b72-43a9-84cd-b6b176bf7868'),
('eadc241d-3986-47f2-b6c7-bec50eec2243');
COMMIT;
