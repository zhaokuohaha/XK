-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        5.5.47 - MySQL Community Server (GPL)
-- 服务器操作系统:                      Win32
-- HeidiSQL 版本:                  9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 导出 xk 的数据库结构
CREATE DATABASE IF NOT EXISTS `xk` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `xk`;


-- 导出  表 xk.users 结构
CREATE TABLE IF NOT EXISTS `users` (
  `u_rid` varchar(50) NOT NULL DEFAULT '000',
  `u_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `u_name` varchar(15) NOT NULL,
  `u_password` varchar(8) DEFAULT NULL,
  `u_level` int(1) unsigned NOT NULL DEFAULT '0' COMMENT '用户级别',
  PRIMARY KEY (`u_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- 正在导出表  xk.users 的数据：~16 rows (大约)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
REPLACE INTO `users` (`u_rid`, `u_id`, `u_name`, `u_password`, `u_level`) VALUES
	('000', 1, 'a', 'a', 3),
	('000', 2, 's', 's', 1),
	('000', 3, 't', 't', 2),
	('000', 4, 'u', 'u', 0),
	('0101', 5, '陈迪茂', 't', 2),
	('0102', 6, '马小红', 't', 2),
	('0103', 7, '吴宝钢', 't', 2),
	('0201', 8, '张心颖', 't', 2),
	('1101', 9, '李明', 's', 1),
	('1102', 10, '刘晓明', 's', 1),
	('1103', 11, '张颖', 's', 1),
	('1104', 12, '刘晶晶', 's', 1),
	('1105', 13, '刘成刚', 's', 1),
	('1106', 14, '李二丽', 's', 1),
	('1107', 15, '张晓峰', 's', 1),
	('16', 16, 'u1', 'u1', 0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;


-- 导出  表 xk.xk_classs 结构
CREATE TABLE IF NOT EXISTS `xk_classs` (
  `cla_id` varchar(21) NOT NULL,
  `cla_name` varchar(21) DEFAULT NULL,
  `cla_dpt_id` varchar(21) DEFAULT NULL,
  `cla_header` varchar(21) DEFAULT NULL,
  PRIMARY KEY (`cla_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_classs 的数据：~8 rows (大约)
/*!40000 ALTER TABLE `xk_classs` DISABLE KEYS */;
REPLACE INTO `xk_classs` (`cla_id`, `cla_name`, `cla_dpt_id`, `cla_header`) VALUES
	('1', '1', '1', '0101'),
	('2', '2', '1', '0101'),
	('3', '3', '1', '0101'),
	('5', '2', '2', '0102'),
	('6', '3', '2', '0102'),
	('7', '1', '3', '0103'),
	('8', '2', '3', '0103'),
	('9', '3', '3', '0103');
/*!40000 ALTER TABLE `xk_classs` ENABLE KEYS */;


-- 导出  表 xk.xk_courseitems 结构
CREATE TABLE IF NOT EXISTS `xk_courseitems` (
  `cori_id` varchar(21) NOT NULL,
  `cori_name` varchar(21) DEFAULT NULL,
  `cori_xuefen` int(10) DEFAULT NULL,
  `cori_dpt_id` varchar(21) DEFAULT NULL,
  PRIMARY KEY (`cori_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_courseitems 的数据：~8 rows (大约)
/*!40000 ALTER TABLE `xk_courseitems` DISABLE KEYS */;
REPLACE INTO `xk_courseitems` (`cori_id`, `cori_name`, `cori_xuefen`, `cori_dpt_id`) VALUES
	('', '', 0, ''),
	('08301001', '分子物理学', 4, '03'),
	('08302001', '通信学', 3, '02'),
	('08305001', '离散数学', 4, '01'),
	('08305002', '数据库原理', 4, '01'),
	('08305003', '数据结构', 4, '01'),
	('08305004', '系统结构', 6, '01'),
	('111', '111', 111, '111');
/*!40000 ALTER TABLE `xk_courseitems` ENABLE KEYS */;


-- 导出  表 xk.xk_courses 结构
CREATE TABLE IF NOT EXISTS `xk_courses` (
  `cor_id` varchar(21) NOT NULL COMMENT '课程号',
  `cor_maxnum` int(3) unsigned NOT NULL DEFAULT '100' COMMENT '人数上限',
  `cor_cid` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT 'Id没有意义',
  `cor_tec_id` varchar(21) NOT NULL DEFAULT '' COMMENT '教师号',
  `cor_time` varchar(21) DEFAULT NULL COMMENT '上课时间',
  `cor_currentnum` int(3) DEFAULT '0' COMMENT '已选人数',
  `cor_iddr` varchar(21) DEFAULT NULL COMMENT '上课地址',
  `cor_trem` varchar(21) DEFAULT NULL COMMENT '学期',
  `cor_type` varchar(21) DEFAULT NULL,
  PRIMARY KEY (`cor_cid`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_courses 的数据：~9 rows (大约)
/*!40000 ALTER TABLE `xk_courses` DISABLE KEYS */;
REPLACE INTO `xk_courses` (`cor_id`, `cor_maxnum`, `cor_cid`, `cor_tec_id`, `cor_time`, `cor_currentnum`, `cor_iddr`, `cor_trem`, `cor_type`) VALUES
	('08302001', 100, 1, '0201', '一5-8', 0, '201', '2013-2014冬季', '专业课'),
	('08305001', 100, 2, '0102', '一5-8', 0, '202', '2013-2014秋季', '专业课'),
	('08305001', 100, 3, '0103', '三5-8', 0, '201', '2012-2013秋季', '专业课'),
	('08305002', 11, 4, '0101', '三1-4', 0, '203', '2012-2013冬季', '专业课'),
	('08305002', 11, 5, '0102', '三1-4', 0, '204', '2012-2013冬季', '专业课'),
	('08305002', 10, 6, '0103', '三1-4', 0, '205', '2012-2013冬季', '专业课'),
	('08305003', 11, 7, '0102', '五5-8', 0, '206', '2012-2013冬季', '专业课'),
	('08305004', 111, 8, '0101', '二1-4', 0, '207', '2013-2014秋季', '专业课'),
	('08305001', 50, 9, '0101', '一1-6', 0, '206', '2015-2016夏季', '专业课');
/*!40000 ALTER TABLE `xk_courses` ENABLE KEYS */;


-- 导出  表 xk.xk_departments 结构
CREATE TABLE IF NOT EXISTS `xk_departments` (
  `dpt_id` varchar(20) NOT NULL,
  `dpt_name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`dpt_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_departments 的数据：~3 rows (大约)
/*!40000 ALTER TABLE `xk_departments` DISABLE KEYS */;
REPLACE INTO `xk_departments` (`dpt_id`, `dpt_name`) VALUES
	('01', '计算机学院'),
	('02', '通讯学院'),
	('03', '材料学院');
/*!40000 ALTER TABLE `xk_departments` ENABLE KEYS */;


-- 导出  表 xk.xk_quote 结构
CREATE TABLE IF NOT EXISTS `xk_quote` (
  `q_id` int(20) NOT NULL AUTO_INCREMENT,
  `q_user` varchar(50) DEFAULT NULL,
  `q_content` text,
  PRIMARY KEY (`q_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='留言表';

-- 正在导出表  xk.xk_quote 的数据：~5 rows (大约)
/*!40000 ALTER TABLE `xk_quote` DISABLE KEYS */;
REPLACE INTO `xk_quote` (`q_id`, `q_user`, `q_content`) VALUES
	(1, 'u12', '这是第一条留言'),
	(2, 'u1', '这是第二条留言'),
	(3, 'u1', '发的'),
	(4, 'u1', '呵呵'),
	(5, 'u', '哈哈哈哈哈');
/*!40000 ALTER TABLE `xk_quote` ENABLE KEYS */;


-- 导出  表 xk.xk_scores 结构
CREATE TABLE IF NOT EXISTS `xk_scores` (
  `sco_id` int(20) unsigned NOT NULL AUTO_INCREMENT COMMENT 'ID没有意义',
  `sco_stu_id` varchar(20) DEFAULT NULL COMMENT '学号',
  `sco_cor_id` varchar(20) DEFAULT NULL COMMENT '学期',
  `sco_cor_term` varchar(20) DEFAULT NULL COMMENT '课程号',
  `sco_tea_id` varchar(20) DEFAULT NULL COMMENT '教师号',
  `sco_value` int(20) DEFAULT NULL COMMENT '分数',
  PRIMARY KEY (`sco_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_scores 的数据：~16 rows (大约)
/*!40000 ALTER TABLE `xk_scores` DISABLE KEYS */;
REPLACE INTO `xk_scores` (`sco_id`, `sco_stu_id`, `sco_cor_id`, `sco_cor_term`, `sco_tea_id`, `sco_value`) VALUES
	(1, '1101', '08305001', '2012-2013秋季', '0103', 60),
	(2, '1102', '08305001', '2012-2013秋季', '0103', 87),
	(3, '1102', '08305002', '2012-2013冬季', '0101', 82),
	(4, '1102', '08305004', '2013-2014秋季', '0101', NULL),
	(5, '1103', '08305001', '2012-2013秋季', '0103', 56),
	(6, '1103', '08305002', '2012-2013冬季', '0102', 75),
	(7, '1103', '08305003', '2012-2013冬季', '0102', 84),
	(8, '1103', '08305001', '2013-2014秋季', '0102', NULL),
	(9, '1103', '08305004', '2013-2014秋季', '0101', NULL),
	(10, '1104', '08305001', '2012-2013秋季', '0103', 74),
	(11, '1104', '08302001', '2013-2014冬季', '0201', NULL),
	(12, '1106', '08305001', '2012-2013秋季', '0103', 85),
	(13, '1106', '08305002', '2012-2013冬季', '0103', 66),
	(14, '1107', '08305001', '2012-2013秋季', '0103', 90),
	(15, '1107', '08305003', '2012-2013冬季', '0102', 79),
	(16, '1107', '08305004', '2013-2014秋季', '0101', NULL);
/*!40000 ALTER TABLE `xk_scores` ENABLE KEYS */;


-- 导出  表 xk.xk_setting 结构
CREATE TABLE IF NOT EXISTS `xk_setting` (
  `st_id` int(11) NOT NULL AUTO_INCREMENT,
  `st_name` varchar(50) NOT NULL,
  `st_value` varchar(50) NOT NULL,
  PRIMARY KEY (`st_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_setting 的数据：~4 rows (大约)
/*!40000 ALTER TABLE `xk_setting` DISABLE KEYS */;
REPLACE INTO `xk_setting` (`st_id`, `st_name`, `st_value`) VALUES
	(1, 'CanSelectCourse', 'true'),
	(2, 'CanUpdateScore', 'true'),
	(3, 'CanSelectCourse', 'false'),
	(4, 'CanUpdateScore', 'true');
/*!40000 ALTER TABLE `xk_setting` ENABLE KEYS */;


-- 导出  表 xk.xk_stus 结构
CREATE TABLE IF NOT EXISTS `xk_stus` (
  `stu_id` varchar(20) NOT NULL,
  `stu_name` varchar(20) DEFAULT NULL,
  `stu_sex` varchar(20) DEFAULT NULL,
  `stu_major` varchar(20) DEFAULT NULL,
  `stu_birth` datetime DEFAULT NULL,
  `stu_Cla_id` varchar(20) DEFAULT NULL,
  `stu_tel` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`stu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_stus 的数据：~7 rows (大约)
/*!40000 ALTER TABLE `xk_stus` DISABLE KEYS */;
REPLACE INTO `xk_stus` (`stu_id`, `stu_name`, `stu_sex`, `stu_major`, `stu_birth`, `stu_Cla_id`, `stu_tel`) VALUES
	('1101', '李明', '男', '计算机', '1993-03-06 00:00:00', '1', '0000001'),
	('1102', '刘晓明', '男', '计算机', '1992-12-08 00:00:00', '1', '0000002'),
	('1103', '张颖', '女', '计算机', '1993-01-05 00:00:00', '2', '0000003'),
	('1104', '刘晶晶', '女', '通信', '1994-11-06 00:00:00', '1', '0000004'),
	('1105', '刘成刚', '男', '通信', '1991-06-07 00:00:00', '1', '0000005'),
	('1106', '李二丽', '女', '材料', '1993-05-04 00:00:00', '1', '0000006'),
	('1107', '张晓峰', '男', '材料', '1992-08-16 00:00:00', '1', '0000007');
/*!40000 ALTER TABLE `xk_stus` ENABLE KEYS */;


-- 导出  表 xk.xk_teachers 结构
CREATE TABLE IF NOT EXISTS `xk_teachers` (
  `tch_id` varchar(20) NOT NULL,
  `tch_name` varchar(20) DEFAULT NULL,
  `tch_sex` varchar(20) DEFAULT NULL,
  `tch_tel` varchar(20) DEFAULT NULL,
  `tch_dpt_id` varchar(20) DEFAULT NULL,
  `tch_pos` varchar(20) DEFAULT '讲师',
  PRIMARY KEY (`tch_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 正在导出表  xk.xk_teachers 的数据：~4 rows (大约)
/*!40000 ALTER TABLE `xk_teachers` DISABLE KEYS */;
REPLACE INTO `xk_teachers` (`tch_id`, `tch_name`, `tch_sex`, `tch_tel`, `tch_dpt_id`, `tch_pos`) VALUES
	('0101', '陈迪茂', '男', '10000001', '01', '教授'),
	('0102', '马小红', '女', '10000002', '01', '副教授'),
	('0103', '吴宝钢', '男', '10000004', '02', '讲师'),
	('0201', '张心颖', '女', '10000003', '02', '讲师');
/*!40000 ALTER TABLE `xk_teachers` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
