Use BestofBooks
GO

INSERT INTO dbo.Author
VALUES 
('Kendra','Elliot'),
('James','Patterson'),
('Allison','Brennan'),
('Lisa','Jackson'),
('Michael','Connelly'),
('Tracy','Wolff'),
('J.K.','Rowling'),
('Caroline','Peckham');

INSERT INTO dbo.Genre
VALUES
('Mystery'),
('Drama'),
('Thriller'),
('Teen & Young Adult'),
('Romance');

INSERT INTO dbo.Book
VALUES
('B07SLZ9LMN','The Last Sister',1,1,1,4,'B2',7.99),
('B082VC2MDY','The Silence',1,1,1,6,'B2',8.99),
('B08GCP767Y','In the Pines',1,1,1,2,'B2',5.99),
('B09PBKF2TM','The First Death',1,1,0,0,null,null),
('B0BDPKGHHQ','At the River',1,1,1,8,'B2',8.99),
('B0BPJLPCN9','The Next Grave',1,1,0,0,null,null),
('B0B9KX9185','North of Nowhere',3,2,1,3,'A4',5.99),
('B000P0JM5O','Step on a Crack',2,3,1,2,'B5',8.99),
('B001PC9ZH6','Run for Your Life',2,3,1,6,'B5',8.99),
('B003G93Z8Q','Worst Case',2,3,1,1,'B5',9.99),
('B0047Y16MG','Tick Tock',2,3,1,8,'B5',7.99),
('B005S9KFSA','I, Michael Bennett',2,3,0,0,null,null),
('B00BAXFAXI','Gone',2,3,1,3,'B5',7.99),
('B00HQ2MXH8','Burn',2,3,1,2,'B5',7.99),
('B00RTY0C6C','Alert',2,3,1,6,'B5',7.99),
('B01A5VQTL2','Bullseye',2,3,0,0,null,null),
('B01N4JZ9YR','Haunted',2,3,1,5,'B5',8.99),
('B079L52TTB','Ambush',2,3,1,2,'B5',9.99),
('B07SJRYDDH','Blindside',2,3,1,12,'B5',5.99),
('B08H1TM3ZR','The Russian',2,3,1,2,'B5',10.99),
('B09L82GKQX','Shattered',2,3,1,1,'B5',12.99),
('B0BLNCCZ7W','Obsessed',2,3,1,5,'B5',13.99),
('B07S4BCQMJ','The Third to Die',3,3,1,5,'B6',11.99),
('B087JTYYSY','Tell No Lies',3,3,1,4,'B6',5.99),
('B096FYD1S5','The Wrong Victim',3,3,1,12,'B6',6.99),
('B0B1QKYK66','Seven Girls Gone',3,3,1,5,'B6',10.99),
('B00PJ50YZ2','Wicked Game',4,3,1,2,'B7',11.99),
('B004NEW50M','Wicked Lies',4,3,1,7,'B7',8.99),
('B00B60D9TW','Something Wicked',4,3,1,4,'B7',5.99),
('B00KFP7Y9K','Wicked Ways',4,3,0,0,null,null),
('B09YL944H1','Wicked Dreams',4,3,1,6,'B7',10.99),
('B000FCKG1G','The Lincoln Lawyer',5,2,1,2,'A3',5.99),
('B0018QOYKC','The Brass Verdict',5,2,1,6,'A3',6.99),
('B003BW0CB6','The Reversal',5,2,0,0,null,null),
('B0047Y17P2','The Fifth Witness',5,2,1,2,'A3',4.99),
('B00BAXFACO','The Gods of Guilt',5,2,0,0,null,null),
('B0852ZXJSD','The Law of Innocence',5,2,0,0,null,null),
('B0BSTZZT12','Resurrection Walk',5,2,1,1,'A3',13.99),
('B07VJ9DJFL','Crave',6,4,1,11,'D2',9.99),
('B086J3PVLQ','Crush',6,4,1,5,'D2',2.99),
('B088QB4VRG','Covet',6,4,1,7,'D2',8.99),
('B08L1PGH7L','Court',6,4,1,2,'D2',10.99),
('B0945ZCKFK','Charm',6,4,1,4,'D2',7.99),
('B09QJNNJLK','Cherish',6,4,1,8,'D2',10.99),
('B0192CTMYG','Harry Potter and the Sorcerers Stone',7,4,1,8,'D2',2.99),
('B0192CTMW8','Harry Potter and the Chamber of Secrets',7,4,1,4,'D2',6.99),
('B0192CTMX2','Harry Potter and the Prisoner of Azkaban',7,4,1,5,'D2',4.99),
('B0192CTMUU','Harry Potter and the Goblet of Fire',7,4,1,3,'D2',5.99),
('B0192CTMXM','Harry Potter and the Order of the Pheonix',7,4,1,8,'D2',7.99),
('B0192CTMWI','Harry Potter and the Half-Blood Prince',7,4,1,16,'D2',4.99),
('B0192CTMWS','Harry Potter and the Deathly Hallows',7,4,1,12,'D2',10.99),
('B086HW5S41','Kings of Quarantine',8,5,1,3,'E8',4.99),
('B086Z3LWDB','Kings of Lockdown',8,5,1,5,'E8',6.99),
('B08BHJK1XQ','Kings of Anarchy',8,5,1,8,'E8',12.99),
('B08HVW5LZM','Queens of Quarantine',8,5,1,2,'E8',10.99);

INSERT INTO dbo.BoBUser
VALUES
('Employee','Boss','boss.employee@bestofbooks.com','bemployee','9F132EEFC74EC853578861D9E790E839027D2153E05DDEC2F719166719423AD7','employee',1,1,1,1,0);

--Note: password for the test admin is 'p@sSw0rd'