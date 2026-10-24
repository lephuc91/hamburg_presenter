<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<!-- Planning Center Playlists -->
	<xsl:template match="NSMutableDictionary[./@containerClass='NSMutableDictionary' and ./NSNumber/@serialization-dictionary-key='playlistType' and ./NSNumber/@serialization-native-value='8']" name="pcoPlaylistNodeTemplate" priority="20">
		<xsl:element name="RVPCOPlaylistNode">
			<xsl:attribute name="UUID">
				<xsl:value-of select="./RVPCOPlanCue/@parentUUID"/>
			</xsl:attribute>
			<xsl:attribute name="isExpanded">false</xsl:attribute>
			<xsl:attribute name="modifiedDate"></xsl:attribute>
			<xsl:attribute name="type">8</xsl:attribute>
			<xsl:apply-templates select="node()[local-name()='RVPCOPlanCue']"/>
			<xsl:element name="array">
				<xsl:attribute name="rvXMLIvarName">events</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="RVPCOPlanCue" name="pcoPlanCueTemplate">
		<xsl:copy>
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:choose>
				<xsl:when test="./@enabled='1'">
					<xsl:attribute name="enabled">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="enabled">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="./@isOffline='1'">
					<xsl:attribute name="isOffline">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="isOffline">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:attribute name="lastUpdated" />
			<xsl:attribute name="rvXMLIvarName">planCue</xsl:attribute>

			<xsl:apply-templates select="@*[local-name()!='enabled' and local-name()!='isOffline' and local-name()!='parentUUID' and local-name()!='serialization-dictionary-key']|node()"/>
		</xsl:copy>
	</xsl:template>
	
	<xsl:template match="RVPCOPlanCue/_-RVPCOPlan-_pcoPlan" name="pcoPlanTemplate" priority="20">
		<xsl:element name="plan">
			<xsl:attribute name="rvXMLIvarName">plan</xsl:attribute>
			<xsl:element name="series_title">
				<xsl:value-of select="@seriesTitle"/>
			</xsl:element>
			<xsl:element name="id">
				<xsl:value-of select="@id"/>
			</xsl:element>
			<xsl:element name="plan_title">
				<xsl:value-of select="@planTitle"/>
			</xsl:element>
			<xsl:element name="dates">
				<xsl:value-of select="@dates"/>
			</xsl:element>
			<xsl:element name="updated_at">
				<xsl:attribute name="type">datetime</xsl:attribute>
				<xsl:value-of select="@updatedAt"/>
			</xsl:element>
			<xsl:element name="created_at">
				<xsl:attribute name="type">datetime</xsl:attribute>
				<xsl:value-of select="@createdAt"/>
			</xsl:element>
			<xsl:apply-templates select="node()[local-name()='items']"/>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="_-RVPCOPlan-_pcoPlan/items" priority="20">
		<xsl:element name="items">
			<xsl:attribute name="type">array</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="_-RVPCOPlanItem-_pcoPlanItem/attachments" priority="20">
		<xsl:element name="attachments">
			<xsl:attribute name="type">array</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="RVPCOPlanItem/attachments" priority="20">
		<xsl:element name="attachments">
			<xsl:attribute name="type">array</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="RVPCOPlanItem|_-RVPCOPlanItem-_pcoPlanItem" name="pcoPlanItemTemplate" priority="10">
		<xsl:element name="item">

			<xsl:attribute name="rvXMLIvarName">planItem</xsl:attribute>

			<xsl:element name="id"><xsl:value-of select="@id"/></xsl:element>
			<xsl:element name="ccli_print_collected">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@ccliPrintCollected='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="is_preservice">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@isPreservice='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="ccli_custom_arrangement">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@ccliCustomArrangement='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="description"><xsl:value-of select="@description"/></xsl:element>
			<xsl:element name="is_header">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="@type='PlanHeader'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="length"><xsl:value-of select="@length"/></xsl:element>
			<xsl:element name="title"><xsl:value-of select="@title"/></xsl:element>
			<xsl:element name="type"><xsl:value-of select="@type"/></xsl:element>
			<xsl:element name="arrangement_sequence_to_s"></xsl:element>
			<xsl:element name="arrangement_id"><xsl:value-of select="@arrangementId"/></xsl:element>
			<xsl:element name="is_postservice">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@isPostservice='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="key_id"><xsl:value-of select="@keyId"/></xsl:element>
			<xsl:element name="ccli_screen">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@ccliScreen='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="ccli_recorded">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@ccliRecorded='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="ccli_print_single">
				<xsl:attribute name="type">boolean</xsl:attribute>
				<xsl:choose>
					<xsl:when test="./@ccliPrintSingle='1'">
						<xsl:value-of select="'true'"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'false'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:element>
			<xsl:element name="sequence"><xsl:value-of select="@sequence"/></xsl:element>
			<xsl:element name="song_id"><xsl:value-of select="@songId"/></xsl:element>
			<xsl:element name="name"></xsl:element>
			<xsl:apply-templates select="node()[local-name()='attachments']"/>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="RVPCOPlanItemCue">
		<xsl:element name="RVPCOPlanHeaderItemCue">
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:choose>
				<xsl:when test="./@enabled='1'">
					<xsl:attribute name="enabled">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="enabled">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="./@isOffline='1'">
					<xsl:attribute name="isOffline">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="isOffline">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>

			<xsl:apply-templates select="@*[local-name(.)!='enabled' and local-name(.)!='isOffline' and local-name(.)!='parentUUID' and local-name(.)!='serialization-array-index']|node()"/>
			
			<xsl:element name="RVHeaderCue">
				<xsl:attribute name="actionType">0</xsl:attribute>
				<xsl:attribute name="color">0.5 0.5 0.5 1</xsl:attribute>
				<xsl:attribute name="delayTime">0.000000</xsl:attribute>
				<xsl:attribute name="displayName"><xsl:value-of select="@displayName"/></xsl:attribute>
				<xsl:attribute name="duration">0.000000</xsl:attribute>
				<xsl:attribute name="enabled">true</xsl:attribute>
				<xsl:attribute name="rvXMLIvarName">headerCue</xsl:attribute>
				<xsl:attribute name="timeStamp">0.000000</xsl:attribute>
				<xsl:attribute name="timerUUID"></xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVPCOPlanMediaItemCue">
		<xsl:element name="RVPCOPlanMediaItemCue">
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:choose>
				<xsl:when test="./@enabled='1'">
					<xsl:attribute name="enabled">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="enabled">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="./@isOffline='1'">
					<xsl:attribute name="isOffline">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="isOffline">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>

			<xsl:apply-templates select="@*[local-name(.)!='enabled' and local-name(.)!='isOffline' and local-name(.)!='parentUUID' and local-name(.)!='serialization-array-index' and local-name(.)!='ignoreIssues' and local-name(.)!='localLinkedDocHasChanges' and local-name(.)!='selectedArrangementID']|node()"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVPCOPlanSongItemCue">
		<xsl:element name="RVPCOPlanSongItemCue">
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:choose>
				<xsl:when test="./@enabled='1'">
					<xsl:attribute name="enabled">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="enabled">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="./@isOffline='1'">
					<xsl:attribute name="isOffline">true</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="isOffline">false</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:apply-templates select="@*[local-name(.)!='enabled' and local-name(.)!='isOffline' and local-name(.)!='parentUUID' and local-name(.)!='serialization-array-index' and local-name(.)!='ignoreIssues' and local-name(.)!='localLinkedDocHasChanges' and local-name(.)!='selectedArrangementID']|node()"/>
			<xsl:if test="not(@filePath='')">
				<xsl:element name="RVDocumentCue">
					<xsl:attribute name="actionType">0</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:attribute name="displayName"><xsl:value-of select="@displayName" /></xsl:attribute>
					<xsl:attribute name="enabled">false</xsl:attribute>
					<xsl:attribute name="filePath"><xsl:value-of select="@filePath" /></xsl:attribute>
					<xsl:attribute name="rvXMLIvarName">documentCue</xsl:attribute>
					<xsl:attribute name="selectedArrangementID"></xsl:attribute>
					<xsl:attribute name="timeStamp">0.000000</xsl:attribute>
				</xsl:element>
			</xsl:if>
			<xsl:element name="array">
				<xsl:attribute name="rvXMLIvarName">pcoSequences</xsl:attribute>
				<xsl:element name="RVPCOSongSequence">
					<xsl:attribute name="id"><xsl:value-of select="_-RVPCOPlanItem-_pcoPlanItem/@id" /></xsl:attribute>
					<xsl:attribute name="sequenceName">Imported Arrangement</xsl:attribute>
				</xsl:element>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="RVPCOAttachment">
		<xsl:element name="attachment">
			<xsl:element name="url"><xsl:value-of select="@urlString"/></xsl:element>
			<xsl:element name="id"><xsl:value-of select="@id"/></xsl:element>
			<xsl:element name="created_at"><xsl:value-of select="@createdAt"/></xsl:element>
			<xsl:element name="size"><xsl:value-of select="@filesize"/></xsl:element>
			<xsl:element name="filename"><xsl:value-of select="@filename"/></xsl:element>
			<xsl:element name="updated_at"><xsl:value-of select="@updatedAt"/></xsl:element>
			<xsl:element name="content_type"><xsl:value-of select="@contentType"/></xsl:element>
		</xsl:element>
	</xsl:template>
	
	<xsl:template match="_-RVPCOAttachment-_localAttachment[not(@*)]"/>	
	<xsl:template match="_-RVMediaCue-_mediaCue[not(@*)]"/>	

	<xsl:template match="_-RVMediaCue-_mediaCue[@*]">
		<xsl:element name="RVMediaCue">
			<xsl:attribute name="rvXMLIvarName">mediaCue</xsl:attribute>
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:attribute name="dateAdded"></xsl:attribute>
			<xsl:attribute name="tags"></xsl:attribute>
			<xsl:apply-templates select="@*[local-name()!='elementClassName' and local-name()!='rvXMLClassName' and local-name()!='blurRadius' and local-name()!='brightness' and local-name()!='colorFilter' and local-name()!='contrast' and local-name()!='edgeBlurArea' and local-name()!='edgeBlurRadius' and local-name()!='enableBlur' and local-name()!='enableColorFilter' and local-name()!='enableColorInvert' and local-name()!='enableEdgeBlur' and local-name()!='enableGrayInvert' and local-name()!='enableHeatSignature' and local-name()!='enableSepia' and local-name()!='hue' and local-name()!='saturation' and local-name()!='serializedFilters']|node()"/>
		</xsl:element>
	</xsl:template>	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	<xsl:template match="/RVPresentationDocument">
		<xsl:element name="RVPresentationDocument">
			<xsl:attribute name="versionNumber">600</xsl:attribute>
			<xsl:attribute name="docType">
				<xsl:choose>
					<xsl:when test="@docType!=''">
						<xsl:value-of select="@docType"/>
					</xsl:when>
					<xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="width">
				<xsl:value-of select="@width"/>
			</xsl:attribute>
			<xsl:attribute name="height">
				<xsl:value-of select="@height"/>
			</xsl:attribute>
			<xsl:attribute name="usedCount">
				<xsl:value-of select="@usedCount"/>
			</xsl:attribute>
			<xsl:attribute name="backgroundColor">
				<xsl:value-of select="@backgroundColor"/>
			</xsl:attribute>
			<xsl:attribute name="drawingBackgroundColor">
				<xsl:choose>
					<xsl:when test="@drawingBackgroundColor='1'">true</xsl:when>
					<xsl:otherwise>false</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="CCLIDisplay">
				<xsl:value-of select="@CCLIDisplay"/>
			</xsl:attribute>
			<xsl:attribute name="lastDateUsed">
				<xsl:choose>
					<xsl:when test="starts-with(@lastDateUsed,'1-')"/>
					<xsl:otherwise>
						<xsl:value-of select="@lastDateUsed"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="selectedArrangementID">
				<xsl:value-of select="@selectedArrangementID"/>
			</xsl:attribute>
			<xsl:attribute name="category">
				<xsl:value-of select="@category"/>
			</xsl:attribute>
			<xsl:attribute name="resourcesDirectory">
				<xsl:value-of select="@resourcesDirectory"/>
			</xsl:attribute>
			<xsl:attribute name="notes">
				<xsl:value-of select="@notes"/>
			</xsl:attribute>
			<xsl:attribute name="chordChartPath">
				<xsl:value-of select="@chordChartPath"/>
			</xsl:attribute>
			<xsl:attribute name="CCLISongTitle">
				<xsl:value-of select="@CCLISongTitle"/>
			</xsl:attribute>
			<xsl:attribute name="CCLIPublisher">
				<xsl:value-of select="@CCLIPublisher"/>
			</xsl:attribute>
			<xsl:attribute name="CCLICopyrightYear">
				<xsl:value-of select="@CCLICopyrightInfo"/>
			</xsl:attribute>
			<xsl:attribute name="CCLISongNumber">
				<xsl:value-of select="@CCLILicenseNumber"/>
			</xsl:attribute>
			<xsl:choose>
				<xsl:when test="@artist!=''">
					<xsl:attribute name="CCLIArtistCredits">
						<xsl:value-of select="@artist"/>
					</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="CCLIArtistCredits">
						<xsl:value-of select="@CCLIArtistCredits"/>
					</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="@author!=''">
					<xsl:attribute name="CCLIAuthor">
						<xsl:value-of select="@author"/>
					</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="CCLIAuthor">
						<xsl:value-of select="@CCLIAuthor"/>
					</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="/RVPresentationDocument/arrangements[not(@containerClass)]">
		<xsl:element name="array">
			<xsl:attribute name="rvXMLIvarName">arrangements</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<xsl:template match="/RVPresentationDocument/slides[@containerClass='NSMutableArray' or not(@containerClass)]">
		<xsl:element name="array">
			<xsl:attribute name="rvXMLIvarName">groups</xsl:attribute>
			<xsl:element name="RVSlideGrouping">
				<xsl:attribute name="name"/>
				<xsl:attribute name="uuid"/>
				<xsl:attribute name="color">0 0 0 0</xsl:attribute>
				<xsl:element name="array">
					<xsl:attribute name="rvXMLIvarName">slides</xsl:attribute>
					<xsl:apply-templates select="node()"/>
				</xsl:element>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<xsl:template match="/RVPlaylistDocument/@versionNumber">
		<xsl:attribute name="versionNumber">600</xsl:attribute>
	</xsl:template>
	<xsl:template match="/RVPlaylistDocument/@creatorCode"/>
	<xsl:template match="/RVPlaylistDocument/@playlistType"/>
	<xsl:template match="/RVPlaylistDocument/deletions[@containerClass='NSMutableArray']">
		<xsl:element name="array">
			<xsl:attribute name="rvXMLIvarName">deletions</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
		<xsl:element name="array">
			<xsl:attribute name="rvXMLIvarName">tags</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<xsl:template match="/RVPlaylistDocument/playlists[@containerClass='NSMutableArray']" name="rootPlaylistNode" priority="10">
		<xsl:element name="RVPlaylistNode">
			<xsl:attribute name="displayName">root</xsl:attribute>
			<xsl:attribute name="type">0</xsl:attribute>
			<xsl:attribute name="isExpanded">false</xsl:attribute>
			<xsl:attribute name="modifiedDate"/>
			<xsl:attribute name="rvXMLIvarName">rootNode</xsl:attribute>
			<xsl:element name="array">
				<xsl:attribute name="rvXMLIvarName">children</xsl:attribute>
				<xsl:apply-templates select="node()"/>
			</xsl:element>
			<xsl:element name="array">
				<xsl:attribute name="rvXMLIvarName">events</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<xsl:template match="/RVPlaylistDocument/deletions/NSMutableDictionary" name="deletionsMatch" priority="100">
		<xsl:element name="RVDeletion">
			<xsl:attribute name="UUID">
				<xsl:value-of select="./NSMutableString/@serialization-native-value"/>
			</xsl:attribute>
			<xsl:attribute name="date">
				<xsl:value-of select="./NSDate/@serialization-native-value"/>
			</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<xsl:template match="NSMutableDictionary[./@containerClass='NSMutableDictionary' and ./NSNumber/@serialization-dictionary-key='playlistType' and not(./NSNumber/@serialization-native-value='8')]" name="genericNonPCOPlaylist" priority="10">
		<xsl:element name="RVPlaylistNode">
			<xsl:attribute name="displayName">
				<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='playlistName']/@serialization-native-value"/>
			</xsl:attribute>
			<xsl:attribute name="UUID">
				<xsl:value-of select="NSMutableString[@serialization-dictionary-key='playlistUUID']/@serialization-native-value"/>
			</xsl:attribute>
			<xsl:attribute name="type">
				<xsl:value-of select="*[starts-with(local-name(.),'NS') and contains(local-name(.),'Number')][@serialization-dictionary-key='playlistType']/@serialization-native-value"/>
			</xsl:attribute>
			<xsl:attribute name="modifiedDate">
				<xsl:value-of select="NSDate[@serialization-dictionary-key='playlistModifiedDate']/@serialization-native-value"/>
			</xsl:attribute>
			<xsl:choose>
				<xsl:when test="*[starts-with(local-name(.),'NS') and contains(local-name(.),'Number')][@serialization-dictionary-key='playlistType']/@serialization-native-value = '4'">
					<xsl:attribute name="smartDirectoryURL">
						<xsl:value-of select="./NSString|NSMutableString[@serialization-dictionary-key='smartDirectory']/@serialization-native-value"/>
					</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="smartDirectoryURL"/>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:element name="array">
				<xsl:attribute name="rvXMLIvarName">children</xsl:attribute>
				<xsl:apply-templates select="NSMutableArray[@serialization-dictionary-key='playlistChildren']/node()"/>
			</xsl:element>
			<xsl:element name="array">
				<xsl:attribute name="rvXMLIvarName">events</xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<!-- Special cases -->
	<!-- handle bible reference dictionary -->
	<xsl:template match="bibleReference[@containerClass='NSMutableDictionary']">
		<xsl:element name="RVBibleReference">
			<xsl:attribute name="translationAbbreviation"/>
			<xsl:attribute name="translationName">
				<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyVersion']"/>
			</xsl:attribute>
			<xsl:attribute name="bookName">
				<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyBookName']"/>
			</xsl:attribute>
			<xsl:attribute name="bookIndex">
				<xsl:choose>
					<xsl:when test="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyBookIndex']/@serialization-native-value!=''">
						<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyBookIndex']/@serialization-native-value"/>
					</xsl:when>
					<xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="chapterStart">
				<xsl:choose>
					<xsl:when test="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyChapterStart']/@serialization-native-value!=''">
						<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyChapterStart']/@serialization-native-value"/>
					</xsl:when>
					<xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="chapterEnd">
				<xsl:choose>
					<xsl:when test="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyChapterStart']/@serialization-native-value!=''">
						<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyChapterStart']/@serialization-native-value"/>
					</xsl:when>
					<xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="verseStart">
				<xsl:choose>
					<xsl:when test="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyChapterStart']/@serialization-native-value!=''">
						<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyChapterStart']/@serialization-native-value"/>
					</xsl:when>
					<xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="verseEnd">
				<xsl:choose>
					<xsl:when test="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyVerseEnd']/@serialization-native-value!=''">
						<xsl:value-of select="./NSMutableString[@serialization-dictionary-key='RVBibleReferenceKeyVerseEnd']/@serialization-native-value"/>
					</xsl:when>
					<xsl:otherwise>0</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="local-name(.)"/>
			</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<!-- convert serializedShadow dictionary to shadow element -->
	<xsl:template match="_-D-_serializedShadow" priority="10">
		<xsl:element name="shadow">
			<xsl:attribute name="rvXMLIvarName">shadow</xsl:attribute>
			<xsl:value-of select="concat(./*[starts-with(local-name(.),'NS') and contains(local-name(.),'Number')]/@serialization-native-value,'|',./NSColor/@serialization-native-value,'|',./NSMutableString/@serialization-native-value)"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVDocumentCue">
		<xsl:element name="RVDocumentCue">
			<xsl:apply-templates select="@*|node()"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="mediaTracks/NSURL">
		<xsl:element name="NSURL">
			<xsl:value-of select="@serialization-native-value"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVDisplaySlide/@sort_index"/>
	<xsl:template match="RVDisplaySlide/@slideType"/>
	<xsl:template match="RVDisplaySlide/cues[not(@containerClass)]">
		<xsl:element name="array">
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="local-name(.)"/>
			</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVDisplaySlide">
		<xsl:element name="RVDisplaySlide">
			<xsl:attribute name="drawingBackgroundColor">
				<xsl:choose>
					<xsl:when test="@drawingBackgroundColor='1'">true</xsl:when>
					<xsl:otherwise>false</xsl:otherwise>
				</xsl:choose>
			</xsl:attribute>
			<xsl:choose>
				<xsl:when test="not(@chordChartPath)">
					<xsl:attribute name="chordChartPath"/>
				</xsl:when>
			</xsl:choose>
			<xsl:apply-templates select="@*[local-name(.)!='drawingBackgroundColor']|node()"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVControlCue">
		<xsl:choose>
			<xsl:when test="./@displayName='Go to Next'">
				<xsl:element name="RVSlideTimerCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:value-of select="./@displayName"/>
					</xsl:attribute>
					<xsl:attribute name="delayTime">
						<xsl:value-of select="./@delayTime"/>
					</xsl:attribute>
					<xsl:attribute name="timeStamp">
						<xsl:value-of select="./@timeStamp"/>
					</xsl:attribute>
					<xsl:attribute name="actionType">0</xsl:attribute>
					<xsl:attribute name="duration">
						<xsl:value-of select="./controlObject/*[@serialization-dictionary-key = 'Timer']/@serialization-native-value"/>
					</xsl:attribute>
					<xsl:attribute name="loopToBeginning">
						<xsl:value-of select="./controlObject/*[@serialization-dictionary-key = 'LoopToBeginning']/@serialization-native-value"/>
					</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:element>
			</xsl:when>
			<xsl:when test="./@displayName='Clear All'">
				<xsl:element name="RVClearCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:value-of select="./@displayName"/>
					</xsl:attribute>
					<xsl:attribute name="actionType">0</xsl:attribute>
					<xsl:attribute name="timeStamp">0</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:element>
			</xsl:when>
			<xsl:when test="./@displayName='Clear Background'">
				<xsl:element name="RVClearCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:value-of select="./@displayName"/>
					</xsl:attribute>
					<xsl:attribute name="actionType">2</xsl:attribute>
					<xsl:attribute name="timeStamp">0</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:element>
			</xsl:when>
			<xsl:when test="./@displayName='Clear Audio'">
				<xsl:element name="RVClearCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:value-of select="./@displayName"/>
					</xsl:attribute>
					<xsl:attribute name="actionType">3</xsl:attribute>
					<xsl:attribute name="timeStamp">0</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:element>
			</xsl:when>
			<xsl:when test="./@displayName='Clear Props'">
				<xsl:element name="RVClearCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:value-of select="./@displayName"/>
					</xsl:attribute>
					<xsl:attribute name="actionType">4</xsl:attribute>
					<xsl:attribute name="timeStamp">0</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:element>
			</xsl:when>
			<xsl:when test="./@displayName='Clear Live Video'">
				<xsl:element name="RVClearCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:value-of select="./@displayName"/>
					</xsl:attribute>
					<xsl:attribute name="actionType">5</xsl:attribute>
					<xsl:attribute name="timeStamp">0</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:element>
			</xsl:when>
			<xsl:when test="contains(./@displayName, 'Slide')">
				<xsl:element name="RVTimelineCue">
					<xsl:attribute name="UUID">
						<xsl:value-of select="./@UUID"/>
					</xsl:attribute>
					<xsl:attribute name="displayName">
						<xsl:choose>
							<xsl:when test="./@displayName = '' or ./@slideIndex = ''">
								<xsl:value-of select="Slide"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="concat(substring-before(./@displayName, ' '),' ',number(./@slideIndex)+1)"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:attribute>
					<xsl:attribute name="actionType">0</xsl:attribute>
					<xsl:choose>
						<xsl:when test="./@enabled='1'">
							<xsl:attribute name="enabled">true</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="enabled">false</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
					<xsl:attribute name="timeStamp">
						<xsl:value-of select="./@timeStamp"/>
					</xsl:attribute>
					<xsl:attribute name="delayTime">0.000000</xsl:attribute>
					<xsl:attribute name="representedObjectUUID">
						<xsl:value-of select="./@slideUUID"/>
					</xsl:attribute>
					<xsl:attribute name="slideIndex">
						<xsl:value-of select="./@slideIndex"/>
					</xsl:attribute>
					<xsl:element name="array">
						<xsl:attribute name="rvXMLIvarName">highlightTimes</xsl:attribute>
						<xsl:apply-templates select="./controlObject/NSMutableArray[@serialization-dictionary-key='timeArray']/*"/>
					</xsl:element>
				</xsl:element>
			</xsl:when>
		</xsl:choose>
	</xsl:template>
	<!-- move elementClassName attribute into element -->
	<xsl:template match="*[contains(local-name(.),'RVMediaCue')]/element">
		<xsl:element name="{../@elementClassName}">
			<xsl:attribute name="rvXMLClassName">
				<xsl:value-of select="../@elementClassName"/>
			</xsl:attribute>
			<xsl:attribute name="rvXMLIvarName">element</xsl:attribute>
			<xsl:if test="contains(../@elementClassName,'RVVideoElement')">
				<xsl:attribute name="frameRate">0</xsl:attribute>
				<xsl:attribute name="fieldType">0</xsl:attribute>
			</xsl:if>
			<xsl:apply-templates select="@*|node()"/>
		<xsl:element name="array">
		<xsl:attribute name="rvXMLIvarName">effects</xsl:attribute>
		<!-- Adjust Color Effects -->
			<xsl:choose>
				<xsl:when test="./@hue!='0' or ./@saturation !='1' or ./@brightness !='0' or ./@contrast !='1'">
                        <xsl:element name="RVEffect">
                            <xsl:attribute name="UUID">D4C199A9-64D7-4CCB-8C26-443E7A9C5C03</xsl:attribute>
                            <xsl:attribute name="displayName">Adjust Color</xsl:attribute>
                                <xsl:element name="array">
                                <xsl:attribute name="rvXMLIvarName">effectVariables</xsl:attribute>
                                    <xsl:element name="RVEffectFloatVariable">
                                        <xsl:attribute name="type">1</xsl:attribute>
                                        <xsl:attribute name="name">Hue</xsl:attribute>
                                        <xsl:attribute name="min">-3.141593</xsl:attribute>
                                        <xsl:attribute name="max">3.141593</xsl:attribute>
                                        <xsl:attribute name="defValue">0.000000</xsl:attribute>
                                        <xsl:attribute name="value"><xsl:value-of select="(./@hue * 3.141593)"/></xsl:attribute>
                                    </xsl:element>
                                    <xsl:element name="RVEffectFloatVariable">
                                        <xsl:attribute name="type">1</xsl:attribute>
                                        <xsl:attribute name="name">Saturation</xsl:attribute>
                                        <xsl:attribute name="min">0.000000</xsl:attribute>
                                        <xsl:attribute name="max">2.000000</xsl:attribute>
                                        <xsl:attribute name="defValue">1.000000</xsl:attribute>
                                        <xsl:attribute name="value"><xsl:value-of select="./@saturation"/></xsl:attribute>
                                    </xsl:element>
                                    <xsl:element name="RVEffectFloatVariable">
                                        <xsl:attribute name="type">1</xsl:attribute>
                                        <xsl:attribute name="name">Brightness</xsl:attribute>
                                        <xsl:attribute name="min">-1.000000</xsl:attribute>
                                        <xsl:attribute name="max">1.000000</xsl:attribute>
                                        <xsl:attribute name="defValue">0.000000</xsl:attribute>
                                        <xsl:attribute name="value"><xsl:value-of select="./@brightness"/></xsl:attribute>
                                    </xsl:element>
                                    <xsl:element name="RVEffectFloatVariable">
                                        <xsl:attribute name="type">1</xsl:attribute>
                                        <xsl:attribute name="name">Contrast</xsl:attribute>
                                        <xsl:attribute name="min">0.000000</xsl:attribute>
                                        <xsl:attribute name="max">2.000000</xsl:attribute>
                                        <xsl:attribute name="defValue">1.000000</xsl:attribute>
                                        <xsl:attribute name="value"><xsl:value-of select="./@contrast"/></xsl:attribute>
                                    </xsl:element>
                                </xsl:element>
                        </xsl:element>						
				</xsl:when>
			</xsl:choose>
		<!-- Blur Effect -->
			<xsl:choose>
				<xsl:when test="./@enableBlur!='0' and ./@blurRadius!='0'">
					<xsl:element name="RVEffect">
                            <xsl:attribute name="UUID">D84CE4A3-D1C3-4F7C-AA75-4C645A3621F2</xsl:attribute>
                            <xsl:attribute name="displayName">Blur</xsl:attribute>
                                <xsl:element name="array">
                                <xsl:attribute name="rvXMLIvarName">effectVariables</xsl:attribute>
                                    <xsl:element name="RVEffectFloatVariable">
                                        <xsl:attribute name="type">1</xsl:attribute>
                                        <xsl:attribute name="name">Blur Amount</xsl:attribute>
                                        <xsl:attribute name="min">0.000000</xsl:attribute>
                                        <xsl:attribute name="max">1.000000</xsl:attribute>
                                        <xsl:attribute name="defValue">0.500000</xsl:attribute>
                                        <xsl:attribute name="value"><xsl:value-of select="(./@blurRadius div 100)"/></xsl:attribute>
                                    </xsl:element>
                                </xsl:element>
                    </xsl:element>
				</xsl:when>
			</xsl:choose>
		<!-- Edge Blur Effect -->
			<xsl:choose>
					<xsl:when test="./@enableEdgeBlur!='0' and ./@edgeBlurRadius!='0'">
						<xsl:element name="RVEffect">
								<xsl:attribute name="UUID">AF83B133-D6A1-487C-BD9E-8579FA49B4E0</xsl:attribute>
								<xsl:attribute name="displayName">Edge Blur</xsl:attribute>
									<xsl:element name="array">
									<xsl:attribute name="rvXMLIvarName">effectVariables</xsl:attribute>
										<xsl:element name="RVEffectFloatVariable">
											<xsl:attribute name="type">1</xsl:attribute>
											<xsl:attribute name="name">Blur Amount</xsl:attribute>
											<xsl:attribute name="min">0.000000</xsl:attribute>
											<xsl:attribute name="max">1.000000</xsl:attribute>
											<xsl:attribute name="defValue">0.500000</xsl:attribute>
											<xsl:attribute name="value"><xsl:value-of select="(./@edgeBlurArea div 100)"/></xsl:attribute>
										</xsl:element>
										<xsl:element name="RVEffectFloatVariable">
											<xsl:attribute name="type">1</xsl:attribute>
											<xsl:attribute name="name">Blur Radius</xsl:attribute>
											<xsl:attribute name="min">0.000000</xsl:attribute>
											<xsl:attribute name="max">1.000000</xsl:attribute>
											<xsl:attribute name="defValue">0.500000</xsl:attribute>
											<xsl:attribute name="value"><xsl:value-of select="(./@edgeBlurRadius div 100)"/></xsl:attribute>
										</xsl:element>
									</xsl:element>
						</xsl:element>
					</xsl:when>
				</xsl:choose>
		<!--Color Filter Effect -->
				<xsl:choose>
					<xsl:when test="./@enableColorFilter!='0'">
						<xsl:element name="RVEffect">
								<xsl:attribute name="UUID">85A535EF-4EFC-4105-B8C7-C65C53376B87</xsl:attribute>
								<xsl:attribute name="displayName">Color Filter</xsl:attribute>
									<xsl:element name="array">
									<xsl:attribute name="rvXMLIvarName">effectVariables</xsl:attribute>
										<xsl:element name="RVEffectColorVariable">
											<xsl:attribute name="type">2</xsl:attribute>
											<xsl:attribute name="name">Blend Color</xsl:attribute>
											<xsl:attribute name="value"><xsl:value-of select="./@colorFilter"/></xsl:attribute>
										</xsl:element>
									</xsl:element>
						</xsl:element>
					</xsl:when>
				</xsl:choose>		
		<!--Sepia Effect -->
				<xsl:choose>
					<xsl:when test="./@enableSepia!='0'">
						<xsl:element name="RVEffect">
								<xsl:attribute name="UUID">06157C8E-D971-4F06-9ECA-2663664E22A6</xsl:attribute>
								<xsl:attribute name="displayName">Sepia</xsl:attribute>
						</xsl:element>
					</xsl:when>
				</xsl:choose>	
		<!--Color Invert Effect -->
				<xsl:choose>
					<xsl:when test="./@enableColorInvert!='0'">
						<xsl:element name="RVEffect">
								<xsl:attribute name="UUID">EDF55F11-1A1E-4BF3-9718-FA2D3731626D</xsl:attribute>
								<xsl:attribute name="displayName">Color Invert</xsl:attribute>
						</xsl:element>
					</xsl:when>
				</xsl:choose>
		<!--Gray Invert Effect -->	
				<xsl:choose>
					<xsl:when test="./@enableGrayInvert!='0'">
						<xsl:element name="RVEffect">
								<xsl:attribute name="UUID">4FDA3849-C39D-4269-AADA-B963944900B7</xsl:attribute>
								<xsl:attribute name="displayName">Gray Invert</xsl:attribute>
						</xsl:element>
					</xsl:when>
				</xsl:choose>
		<!--Heat Signature Effect -->	
				<xsl:choose>
					<xsl:when test="./@enableHeatSignature!='0'">
						<xsl:element name="RVEffect">
								<xsl:attribute name="UUID">F3F254AF-BF83-412D-B802-51E42A25FDF9</xsl:attribute>
								<xsl:attribute name="displayName">Heat Signature</xsl:attribute>
						</xsl:element>
					</xsl:when>
				</xsl:choose>		
	<!--Effects Done -->	
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<!-- arrangements array -->
	<xsl:template match="arrangements|cues">
		<xsl:copy>
			<xsl:attribute name="rvXMLClassName">NSMutableArray</xsl:attribute>
			<xsl:apply-templates select="@*|node()"/>
		</xsl:copy>
	</xsl:template>
	<!-- handle DVD Dispatch cues -->
	<xsl:template match="RVDispatchCue[@payloadClassName='RVDVDClip']/payload">
		<xsl:element name="RVDVDClip">
			<xsl:apply-templates select="@*[local-name(.)!='bookmarkData']|node()"/>
			<xsl:attribute name="rvXMLIvarName">dvdClip</xsl:attribute>
			<xsl:element name="NSData">
				<xsl:attribute name="rvXMLIvarName">bookmarkData</xsl:attribute>
				<xsl:value-of select="./@bookmarkData"/>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVDispatchCue[@payloadClassName='RVDVDClip']">
		<xsl:element name="RVDVDCue">
			<xsl:attribute name="UUID">
				<xsl:value-of select="./@UUID"/>
			</xsl:attribute>
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:attribute name="delayTime">0.000000</xsl:attribute>
			<xsl:attribute name="displayName">
				<xsl:value-of select="./@displayName"/>
			</xsl:attribute>
			<xsl:attribute name="enabled">false</xsl:attribute>
			<xsl:attribute name="timeStamp">0.000000</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
	</xsl:template>
	<!-- handle Audio Dispatch cues -->
	<xsl:template match="RVDispatchCue[@payloadClassName='RVAudioElement']/payload">
		<xsl:element name="RVAudioElement">
			<xsl:apply-templates select="@*|node()"/>
			<xsl:attribute name="rvXMLIvarName">element</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<xsl:template match="RVDispatchCue[@payloadClassName='RVAudioElement']">
		<xsl:element name="RVAudioCue">
			<xsl:attribute name="UUID">
				<xsl:value-of select="./@UUID"/>
			</xsl:attribute>
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:attribute name="delayTime">0.000000</xsl:attribute>
			<xsl:attribute name="displayName">
				<xsl:value-of select="./@displayName"/>
			</xsl:attribute>
			<xsl:attribute name="enabled">false</xsl:attribute>
			<xsl:attribute name="timeStamp">0.000000</xsl:attribute>
			<xsl:apply-templates select="node()"/>
		</xsl:element>
	</xsl:template>
	<!-- handle File Dispatch cues -->
	<xsl:template match="RVDispatchCue[@payloadClassName='RVFileElement']">
		<xsl:element name="RVPresentationScriptCue">
			<xsl:attribute name="UUID">
				<xsl:value-of select="./@UUID"/>
			</xsl:attribute>
			<xsl:attribute name="action">0</xsl:attribute>
			<xsl:attribute name="actionType">0</xsl:attribute>
			<xsl:attribute name="delayTime">0.000000</xsl:attribute>
			<xsl:attribute name="displayName">
				<xsl:value-of select="./@displayName"/>
			</xsl:attribute>
			<xsl:attribute name="enabled">false</xsl:attribute>
			<xsl:attribute name="timeStamp">0.000000</xsl:attribute>
			<xsl:attribute name="filePath">
				<xsl:value-of select="./payload/@source"/>
			</xsl:attribute>
		</xsl:element>
	</xsl:template>
	<!-- convert timeline to RVTimeline element -->
	<xsl:template match="timeline" priority="10">
		<xsl:element name="RVTimeline">
			<xsl:attribute name="rvXMLIvarName">timeline</xsl:attribute>
			<xsl:attribute name="timeOffset">
				<xsl:value-of select="@timeOffSet"/>
			</xsl:attribute>
			<xsl:apply-templates select="@*[local-name(.)!='timeOffSet' and local-name(.)!='unitOfMeasure']|node()"/>
		</xsl:element>
	</xsl:template>
	<!-- convert RVTextElement -->
	<xsl:template match="RVTextElement" priority="10">
		<xsl:copy>
			<xsl:choose>
				<xsl:when test="not(@revealType)">
					<xsl:attribute name="revealType">0</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:attribute name="UUID"/>
			<xsl:apply-templates select="@*[local-name(.)!='RTFData'] | node()"/>
			<xsl:element name="NSString">
				<xsl:attribute name="rvXMLIvarName">RTFData</xsl:attribute>
				<xsl:value-of select="@RTFData"/>
			</xsl:element>
		</xsl:copy>
	</xsl:template>
	<!-- convert RVImageElement/RVVideoElement -->
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@blurRadius"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@brightness"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@colorFilter"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@contrast"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@edgeBlurArea"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@edgeBlurRadius"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableBlur"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableColorFilter"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableColorInvert"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableEdgeBlur"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableGrayInvert"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableHeatSignature"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@enableSepia"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@hue"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@saturation"/>
	<xsl:template match="*[local-name(.)='RVImageElement' or local-name(.)='RVVideoElement']/@serializedFilters"/>
	<xsl:template match="RVImageElement|RVVideoElement" priority="10">
		<xsl:copy>
			<xsl:attribute name="scaleSize">{1,1}</xsl:attribute>
			<xsl:attribute name="imageOffset">{0,0}</xsl:attribute>
			<xsl:attribute name="UUID"/>
			<xsl:apply-templates select="@*[local-name(.)!='scaleFactor' and local-name(.)!='serializedImageOffset'] | node()"/>
		</xsl:copy>
	</xsl:template>
	<!-- convert Transitions -->
	<xsl:template match="*[contains(local-name(.),'_-RVProTransitionObject-_') and not(@*)]" priority="10"/>
	<xsl:template match="*[contains(local-name(.),'_-RVProTransitionObject-_')]" priority="5">
		<xsl:element name="RVTransition">
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="substring-after(local-name(.),'-_')"/>
			</xsl:attribute>
			<xsl:attribute name="transitionDirection">0</xsl:attribute>
			<xsl:attribute name="groupIndex">0</xsl:attribute>
			<xsl:attribute name="orderIndex">0</xsl:attribute>
			<xsl:attribute name="slideBuildAction">0</xsl:attribute>
			<xsl:attribute name="slideBuildDelay">0</xsl:attribute>
			<xsl:apply-templates select="@*|node()"/>
		</xsl:element>
	</xsl:template>
	<!-- convert positions -->
	<xsl:template match="*[contains(local-name(.),'_-RVRect3D-_')]" priority="5">
		<xsl:element name="RVRect3D">
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="substring-after(local-name(.),'-_')"/>
			</xsl:attribute>
			<xsl:value-of select="concat('{',./@x,' ',./@y,' ',./@z,' ',./@width,' ',./@height,'}')"/>
		</xsl:element>
	</xsl:template>
	<!-- Convert Arrays -->
	<xsl:template match="*[@containerClass='NSMutableArray']" priority="2">
		<array>
			<xsl:choose>
				<xsl:when test="./@serialization-dictionary-key">
					<xsl:attribute name="rvXMLDictionaryKey">
						<xsl:value-of select="./@serialization-dictionary-key"/>
					</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="local-name(.)"/>
			</xsl:attribute>
			<xsl:apply-templates/>
		</array>
	</xsl:template>
	<!-- Convert Dictionaries -->
	<xsl:template match="*[@containerClass='NSMutableDictionary']" priority="2">
		<dictionary>
			<xsl:choose>
				<xsl:when test="./@serialization-dictionary-key">
					<xsl:attribute name="rvXMLDictionaryKey">
						<xsl:value-of select="./@serialization-dictionary-key"/>
					</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="local-name(.)"/>
			</xsl:attribute>
			<xsl:apply-templates/>
		</dictionary>
	</xsl:template>
	<!-- Strip _-x-_ from names -->
	<xsl:template match="*[contains(local-name(.),'_-') and contains(local-name(.),'-_')]" priority="3">
		<xsl:element name="{substring-after(local-name(.),'-_')}">
			<xsl:attribute name="rvXMLClassName">
				<xsl:value-of select="substring-before(substring-after(local-name(.),'_-'),'-_')"/>
			</xsl:attribute>
			<xsl:attribute name="rvXMLIvarName">
				<xsl:value-of select="substring-after(local-name(.),'-_')"/>
			</xsl:attribute>
			<xsl:apply-templates select="@*|node()"/>
		</xsl:element>
	</xsl:template>
	<!-- Misc Cleanup -->
	<xsl:template match="@serialization-array-index" priority="100"/>
	<xsl:template match="@serialization-dictionary-key" priority="100">
		<xsl:attribute name="rvXMLDictionaryKey">
			<xsl:value-of select="."/>
		</xsl:attribute>
	</xsl:template>
	<xsl:template match="*[starts-with(local-name(.),'NS') and contains(local-name(.),'Number')]" priority="4">
		<xsl:element name="NSNumber">
			<xsl:apply-templates/>
			<xsl:choose>
				<xsl:when test="./@serialization-dictionary-key">
					<xsl:attribute name="rvXMLDictionaryKey">
						<xsl:value-of select="./@serialization-dictionary-key"/>
					</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:choose>
				<xsl:when test="contains(@serialization-native-value,'.')">
					<xsl:attribute name="hint">double</xsl:attribute>
				</xsl:when>
				<xsl:when test="@serialization-native-value='YES' or @serialization-native-value='NO'">
					<xsl:attribute name="hint">bool</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="hint">integer</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
			<xsl:value-of select="@serialization-native-value"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="*[starts-with(local-name(.),'NS') and contains(local-name(.),'String')]">
		<xsl:element name="NSMutableString">
			<xsl:apply-templates/>
			<xsl:choose>
				<xsl:when test="./@serialization-dictionary-key">
					<xsl:attribute name="rvXMLDictionaryKey">
						<xsl:value-of select="./@serialization-dictionary-key"/>
					</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:value-of select="@serialization-native-value"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="*[starts-with(local-name(.),'NS') and contains(local-name(.),'Color')]">
		<xsl:element name="NSColor">
			<xsl:apply-templates/>
			<xsl:choose>
				<xsl:when test="./@serialization-dictionary-key">
					<xsl:attribute name="rvXMLDictionaryKey">
						<xsl:value-of select="./@serialization-dictionary-key"/>
					</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:value-of select="@serialization-native-value"/>
		</xsl:element>
	</xsl:template>
	<xsl:template match="*[starts-with(local-name(.),'NS') and contains(local-name(.),'URL')]">
		<xsl:element name="NSURL">
			<xsl:apply-templates/>
			<xsl:choose>
				<xsl:when test="./@serialization-dictionary-key">
					<xsl:attribute name="rvXMLDictionaryKey">
						<xsl:value-of select="./@serialization-dictionary-key"/>
					</xsl:attribute>
				</xsl:when>
			</xsl:choose>
			<xsl:value-of select="@serialization-native-value"/>
		</xsl:element>
	</xsl:template>
	<!-- Pass Everything Else Through -->
	<xsl:template match="@containerClass"/>
	<xsl:template match="@*|node()" name="passthrough">
		<xsl:copy>
			<xsl:apply-templates select="@*|node()"/>
		</xsl:copy>
	</xsl:template>
</xsl:stylesheet>
