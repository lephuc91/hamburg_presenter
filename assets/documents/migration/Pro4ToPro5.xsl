<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	
	<xsl:template match="*[local-name() = 'RVPlaylistDocument' or local-name() = 'RVPresentationDocument']/@versionNumber">
		<xsl:attribute name="versionNumber">500</xsl:attribute>
	</xsl:template>
    
	<xsl:template match="controlObject/NSNumber">
		<xsl:choose>
			<xsl:when test="@serialization-dictionary-key='slide_index' or @serialization-dictionary-key='Timer' or @serialization-dictionary-key='Action' or @serialization-dictionary-key='LoopToBeginning'">
				<xsl:element name="NSMutableString">
					<xsl:apply-templates select="@*"/>
				</xsl:element>
			</xsl:when>
			<xsl:otherwise>
				<xsl:copy>
					<xsl:apply-templates select="@*"/>
				</xsl:copy>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>

	<xsl:template match="NSMutableDictionary[./*/@serialization-dictionary-key='filePath']">
		<xsl:element name="RVDocumentCue">
			<xsl:attribute name="UUID"></xsl:attribute>
			<xsl:attribute name="delayTime">0</xsl:attribute>
			<xsl:attribute name="displayName"><xsl:value-of select="./*[@serialization-dictionary-key='displayName']/@serialization-native-value"/></xsl:attribute>
			<xsl:attribute name="enabled">1</xsl:attribute>
			<xsl:attribute name="filePath"><xsl:value-of select="./*[@serialization-dictionary-key='filePath']/@serialization-native-value"/></xsl:attribute>
			<xsl:attribute name="parentUUID"></xsl:attribute>
			<xsl:attribute name="selectedArrangementID">0</xsl:attribute>
			<xsl:attribute name="serialization-array-index"><xsl:value-of select="./@serialization-array-index"/></xsl:attribute>
			<xsl:attribute name="timeStamp">0</xsl:attribute>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="mediaTracks/NSURL">
		<xsl:element name="NSMutableString">
			<xsl:apply-templates select="@*"/>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="RVPresentationDocument|RVDisplaySlide">
		<xsl:copy>
			<xsl:apply-templates select="@*"/>
			<xsl:attribute name="chordChartPath"></xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
	</xsl:template>
	
	<xsl:template match="RVTextElement">
		<xsl:copy>
			<xsl:apply-templates select="@*"/>
			<xsl:attribute name="revealType">0</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
	</xsl:template>
	
	<xsl:template match="RVImageElement|RVVideoElement|RVLiveVideoElement|RVMediaCue/element">
		<xsl:copy>
			<xsl:apply-templates select="@*"/>
			<xsl:attribute name="enableColorFilter">0</xsl:attribute>
			<xsl:attribute name="colorFilter">1 0 0 1</xsl:attribute>
			<xsl:attribute name="enableBlur">0</xsl:attribute>
			<xsl:attribute name="blurRadius">0</xsl:attribute>
			<xsl:attribute name="enableEdgeBlur">0</xsl:attribute>
			<xsl:attribute name="edgeBlurRadius">0</xsl:attribute>
			<xsl:attribute name="edgeBlurArea">0</xsl:attribute>
			<xsl:attribute name="enableSepia">0</xsl:attribute>
			<xsl:attribute name="enableColorInvert">0</xsl:attribute>
			<xsl:attribute name="enableGrayInvert">0</xsl:attribute>
			<xsl:attribute name="enableHeatSignature">0</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:copy>
	</xsl:template>
	
	<xsl:template match="slides">
		<xsl:element name="groups">
			<xsl:attribute name="containerClass">NSMutableArray</xsl:attribute>
			<xsl:element name="RVSlideGrouping">
				<xsl:attribute name="name">Slide Grouping 1</xsl:attribute>
				<xsl:attribute name="color">0 0 0 0</xsl:attribute>
				<xsl:attribute name="serialization-array-index">0</xsl:attribute>
				<xsl:copy>
					<xsl:apply-templates select="@*|node()"/>
				</xsl:copy>
			</xsl:element>
		</xsl:element>
	</xsl:template>

	<xsl:template match="_-D-_serializedShadow">
		<xsl:element name="_-D-_serializedShadow">
			<xsl:attribute name="containerClass">NSMutableDictionary</xsl:attribute>
			<xsl:element name="NSNumber">
				<xsl:attribute name="serialization-native-value">
					<xsl:value-of select="./*[starts-with(local-name(.),'NS') and contains(local-name(.),'Number')]/@serialization-native-value"/>
				</xsl:attribute>
				<xsl:attribute name="serialization-dictionary-key">shadowBlurRadius</xsl:attribute>
			</xsl:element>
			<xsl:element name="NSColor">
				<xsl:attribute name="serialization-native-value">
					<xsl:value-of select="./*[starts-with(local-name(.),'NS') and contains(local-name(.),'Color')]/@serialization-native-value"/>
				</xsl:attribute>
				<xsl:attribute name="serialization-dictionary-key">shadowColor</xsl:attribute>
			</xsl:element>
			<xsl:element name="NSMutableString">
				<xsl:attribute name="serialization-native-value">
					<xsl:value-of select="./*[starts-with(local-name(.),'NS') and contains(local-name(.),'String')]/@serialization-native-value"/>
				</xsl:attribute>
				<xsl:attribute name="serialization-dictionary-key">shadowOffset</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	
	<!-- Pass Everything Else Through -->
	<xsl:template match="@*|node()">
		<xsl:copy>
			<xsl:apply-templates select="@*|node()"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>



